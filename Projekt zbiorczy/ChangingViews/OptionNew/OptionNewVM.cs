using ChangingViews.DialogWindow;
//using GalaSoft.MvvmLight.Command;
using ChangingViews.Utils;
//using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace ChangingViews.OptionNew
{
    public class OptionNewVM : ObserverVM
    {
        private readonly ViewManager viewManager;

        public OptionNewVM(ViewManager viewManager)
        {
            this.viewManager = viewManager;
        }

        public OptionNewVM()
        {

        }

        public string opis;
        public string OpisDialogWindowVM
        {
            get => opis;
            set
            {
                opis = value;
                OnPropertyChanged(nameof(OpisDialogWindowVM));
            }
        }

        private ICommand getTextCommand;

        public ICommand GetTextCommand
        {
            get
            {
                if (getTextCommand == null)
                {
                    getTextCommand = new RelayCommand<object>(
                        o =>
                        {
                            DialogWindowVM dialogWindowVM = new DialogWindowVM(viewManager)
                            {
                                DialogText = "Testowe wywolanie",
                                ShowOkButton = true,
                                ShowInputText = true
                            };

                            viewManager.AddViewModel(dialogWindowVM, true, () => OpisDialogWindowVM = dialogWindowVM.DialogInputText);
                        });
                }

                return getTextCommand;
            }
        }

    }
}
