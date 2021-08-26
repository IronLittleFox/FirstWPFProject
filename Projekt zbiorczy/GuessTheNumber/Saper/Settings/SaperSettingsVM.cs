using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuessTheNumber.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Saper.Settings
{
    class SaperSettingsVM : ViewModelBase
    {
        public SaperSettingsVM()
        {
            RowCount = SaperSettings.RowCount;
            ColCount = SaperSettings.ColCount;
        }


        private int rowCount = 0;
        public int RowCount
        {
            get
            {
                return rowCount;
            }

            set
            {
                if (rowCount == value)
                {
                    return;
                }

                rowCount = value;
                SaperSettings.RowCount = value;
                RaisePropertyChanged();
            }
        }

        private int colCount = 0;
        public int ColCount
        {
            get
            {
                return colCount;
            }

            set
            {
                if (colCount == value)
                {
                    return;
                }

                colCount = value;
                SaperSettings.ColCount = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand returnToHomeWindowCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand ReturnToHomeWindowCommand
        {
            get
            {
                return returnToHomeWindowCommand
                    ?? (returnToHomeWindowCommand = new RelayCommand(
                    () =>
                    {
                        ChangeMainViewMessage.Send("HomeWindow");
                        //Messenger.Default.Send("HomeWindow", "ChangeMainView");
                    }));
            }
        }

    }
}
