using ChangingViews.OptionNew;
using ChangingViews.OptionOpen;
using ChangingViews.Utils;
using System.Windows.Input;

namespace ChangingViews.MainWindow
{
    public class MainWindowVM : ObserverVM
    {
        private readonly ViewManager viewManager;

        public MainWindowVM()
        {
            viewManager = new ViewManager(()=> OnPropertyChanged(new[] { "SelectedViewModel", "EnableMainMenu" }), () => OnPropertyChanged(new[] {"EnableMainMenu" }));
        }

        public object SelectedViewModel
        {
            get => viewManager.SelectedViewModel;
            set => viewManager.AddViewModel(value);
        }

        public bool EnableMainMenu => viewManager.SelectedViewModel == null;

        public ICommand PrevCommand => viewManager.PrevCommand;

        private ICommand newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand<object>(
                        o =>
                        {
                            SelectedViewModel = new OptionNewVM(viewManager);
                        });
                }

                return newCommand;
            }
        }

        private ICommand openCommand;

        public ICommand OpenCommand
        {
            get
            {
                if (openCommand == null)
                {
                    openCommand = new RelayCommand<object>(
                        o =>
                        {
                            SelectedViewModel = new OptionOpenVM();
                        });
                }

                return openCommand;
            }
        }
    }
}
