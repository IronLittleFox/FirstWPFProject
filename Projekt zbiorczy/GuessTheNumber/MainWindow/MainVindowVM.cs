using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GuessTheNumber.DataGrid.Employees;
using GuessTheNumber.Game.GameWindow;
using GuessTheNumber.HomeWindow;
using GuessTheNumber.LoadFile;
using GuessTheNumber.RotateImage;
using GuessTheNumber.Game.SettingsGameWindow;
using GuessTheNumber.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheNumber.DataGrid.Person;
using GuessTheNumber.Saper.Game;
using GuessTheNumber.Saper.Settings;

namespace GuessTheNumber.MainWindow
{
    public class MainVindowVM : ViewModelBase
    {

        public MainVindowVM()
        {
            SelectedViewModel = new HomeWindowVM();
            ChangeMainViewMessage.Register(this, ChangeMainView);
            //Messenger.Default.Register<string>(this, "ChangeMainView", ChangeMainView);
        }

        private void ChangeMainView(string message)
        {
            if (message == "HomeWindow")
                SelectedViewModel = new HomeWindowVM();
        }

        private ViewModelBase viewModelBase = null;
        public ViewModelBase SelectedViewModel
        {
            get
            {
                return viewModelBase;
            }
            set
            {
                if (viewModelBase == value)
                {
                    return;
                }
                viewModelBase = value;
                RaisePropertyChanged(nameof(SelectedViewModel));
            }
        }

        private bool enableMainMenu = true;
        public bool EnableMainMenu
        {
            get
            {
                return enableMainMenu;
            }
            set
            {
                if (enableMainMenu == value)
                {
                    return;
                }
                enableMainMenu = value;
                RaisePropertyChanged(nameof(EnableMainMenu));
            }
        }

        private RelayCommand newGameCommand;
        public RelayCommand NewGameCommand
        {
            get
            {
                return newGameCommand
                    ?? (newGameCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new GameWindowVM();
                    }));
            }
        }

        private RelayCommand optionCommand;
        public RelayCommand OptionCommand
        {
            get
            {
                return optionCommand
                    ?? (optionCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new SettingsGameWindowVM();
                    }));
            }
        }
        private RelayCommand loadFileCommand;
        public RelayCommand LoadFileCommand
        {
            get
            {
                return loadFileCommand
                    ?? (loadFileCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new LoadFileVM();
                    }));
            }
        }

        private RelayCommand rotateImageCommand;
        public RelayCommand RotateImageCommand
        {
            get
            {
                return rotateImageCommand
                    ?? (rotateImageCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new RotateImageVM();
                    }));
            }
        }
        private RelayCommand employeesCommand;
        public RelayCommand EmployeesCommand
        {
            get
            {
                return employeesCommand
                    ?? (employeesCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new EmployeesVM();
                    }));
            }
        }
        
        private RelayCommand personCommand;
        public RelayCommand PersonCommand
        {
            get
            {
                return personCommand
                    ?? (personCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new PersonVM();
                    }));
            }
        }

        private RelayCommand saperCommand;
        public RelayCommand SaperCommand
        {
            get
            {
                return saperCommand
                    ?? (saperCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new SaperVM();
                    }));
            }
        }

        private RelayCommand saperSettingCommand;
        public RelayCommand SaperSettingCommand
        {
            get
            {
                return saperSettingCommand
                    ?? (saperSettingCommand = new RelayCommand(
                    () =>
                    {
                        SelectedViewModel = new SaperSettingsVM();
                    }));
            }
        }

    }
}
