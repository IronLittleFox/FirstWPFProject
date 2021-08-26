using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GuessTheNumber.Game.Settings;
using GuessTheNumber.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Game.SettingsGameWindow
{
    class SettingsGameWindowVM : ViewModelBase
    {
        public SettingsGameWindowVM()
        {
            MaxRange = GameSettings.MaxRange;
        }
        private int maxRange = 0;
        public int MaxRange
        {
            get
            {
                return maxRange;
            }

            set
            {
                if (maxRange == value)
                {
                    return;
                }

                maxRange = value;
                GameSettings.MaxRange = value;
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
