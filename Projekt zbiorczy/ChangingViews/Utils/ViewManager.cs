using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ChangingViews.Utils
{
    public class ViewManager
    {
        private readonly Stack<object> stackOfSelectedVieWModels = new Stack<object>();

        private object selectedViewModel;
        private bool isDialogViewModel;
        private Action actionWhenCloseDialogViewModel;
        private Action actionWhenOnPropertyChangedNamesAdd;
        private Action actionWhenonPropertyChangedNamesRemove;


        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            private set
            {
                selectedViewModel = value;
                actionWhenOnPropertyChangedNamesAdd?.Invoke();
            }
        }

        public ViewManager(Action actionWhenOnPropertyChangedNamesAdd, Action actionWhenonPropertyChangedNamesRemove)
        {
            this.actionWhenOnPropertyChangedNamesAdd = actionWhenOnPropertyChangedNamesAdd;
            this.actionWhenonPropertyChangedNamesRemove = actionWhenonPropertyChangedNamesRemove;
        }

        public void AddViewModel(object viewModel, bool isDialogViewModel = false, Action actionWhenCloseDialogViewModel = null)
        {
            if (isDialogViewModel && this.isDialogViewModel)
            {
                throw new Exception("Double dialog windows cannot be opened");
            }

            this.actionWhenCloseDialogViewModel = actionWhenCloseDialogViewModel;

            this.isDialogViewModel = isDialogViewModel;
            stackOfSelectedVieWModels.Push(SelectedViewModel);
            SelectedViewModel = viewModel;
        }

        public object RemoveViewModel()
        {
            isDialogViewModel = false;

            object removeViewModel = SelectedViewModel;
            SelectedViewModel = stackOfSelectedVieWModels.Pop();

            actionWhenonPropertyChangedNamesRemove?.Invoke();

            actionWhenCloseDialogViewModel?.Invoke();
            actionWhenCloseDialogViewModel = null;

            return removeViewModel;
        }

        private ICommand prevCommand;

        public ICommand PrevCommand
        {
            get
            {
                if (prevCommand == null)
                    prevCommand = new RelayCommand<object>(
                        o =>
                        {
                            RemoveViewModel();
                        },
                        o =>
                        {
                            return stackOfSelectedVieWModels.Count > 0 && !isDialogViewModel;
                        });
                return prevCommand;
            }
        }

    }
}
