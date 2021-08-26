using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuessTheNumber.Game.Settings;
using System;
using System.Windows.Input;

namespace GuessTheNumber.Game.GameWindow
{
    public class GameWindowVM : ViewModelBase
    {
        private int SecretNumber;
        private bool IsSolved;
        public GameWindowVM()
        {
            
            NewGame();
        }

        private string informativeMessage;
        public string InformativeMessage
        {
            get
            {
                return informativeMessage;
            }

            set
            {
                if (informativeMessage == value)
                {
                    return;
                }
                informativeMessage = value;
                RaisePropertyChanged();
            }
        }

        private int guessingNumber;
        public int GuessingNumber
        {
            get
            {
                return guessingNumber;
            }

            set
            {
                if (guessingNumber == value)
                {
                    return;
                }
                guessingNumber = value;
                RaisePropertyChanged();
            }
        }

        private string messageOnButton;
        public string MessageOnButton
        {
            get
            {
                return messageOnButton;
            }

            set
            {
                if (messageOnButton == value)
                {
                    return;
                }

                messageOnButton = value;
                RaisePropertyChanged();
            }
        }

        private string hintForTheAnswer;
        public string HintForTheAnswer
        {
            get
            {
                return hintForTheAnswer;
            }

            set
            {
                if (hintForTheAnswer == value)
                {
                    return;
                }

                hintForTheAnswer = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand<object> checkTheNumberCommand;
        public RelayCommand<object> CheckTheNumberCommand
        {
            get
            {
                return checkTheNumberCommand
                    ?? (checkTheNumberCommand = new RelayCommand<object>((object o) =>
                    {
                        if (o is KeyEventArgs)
                        {
                            if (((KeyEventArgs)o).Key != Key.Enter)
                                return;
                        }

                        if (IsSolved)
                        {
                            NewGame();
                            IsSolved = false;
                            return;
                        }

                        if (GuessingNumber < SecretNumber)
                            HintForTheAnswer = "Liczba jest za mała";
                        else if (GuessingNumber > SecretNumber)
                            HintForTheAnswer = "Liczba jest za duża";
                        else
                        {
                            HintForTheAnswer = "Gratulacje. Odgadłeś liczbę";
                            MessageOnButton = "Kliknij aby zacząć nową grę";
                        }
                        IsSolved = GuessingNumber == SecretNumber;
                    }));
            }
        }

        public void NewGame()
        {
            Random rnd = new Random();
            SecretNumber = rnd.Next(0, GameSettings.MaxRange);
            HintForTheAnswer = "";
            InformativeMessage = "Wpisz liczbę:";
            MessageOnButton = "Sprawdź liczbę";
        }
    }
}
