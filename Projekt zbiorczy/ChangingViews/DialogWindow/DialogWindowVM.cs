using ChangingViews.Utils;
using System.Windows.Input;

namespace ChangingViews.DialogWindow
{
    public enum ButtonStatus { OK, Save, Cancel };
    public class DialogWindowVM
    {
        private ViewManager viewManager;
        public string DialogText { get; set; }
        public string DialogInputText { get; set; }
        public bool ShowInputText { get; set; }
        public bool ShowOkButton { get; set; }
        public bool ShowSaveButton { get; set; }
        public bool ShowCancelButton { get; set; }

        public ButtonStatus ButtonStatus { get; set; }

        public DialogWindowVM()
        {

        }

        public DialogWindowVM(ViewManager viewManager)
        {
            this.viewManager = viewManager;
        }

        private ICommand buttonCommand;

        public ICommand ButtonCommand
        {
            get
            {
                if (buttonCommand == null)
                {
                    buttonCommand = new RelayCommand<object>(
                        o =>
                        {
                            string whichButton = o.ToString();
                            switch(whichButton)
                            {
                                case "OK":
                                    ButtonStatus = ButtonStatus.OK;
                                    break;
                                case "Save":
                                    ButtonStatus = ButtonStatus.Save;
                                    break;
                                case "Cancel":
                                    ButtonStatus = ButtonStatus.Cancel;
                                    break;
                            }
                            viewManager.RemoveViewModel();
                        });
                }

                return buttonCommand;
            }
        }

    }
}
