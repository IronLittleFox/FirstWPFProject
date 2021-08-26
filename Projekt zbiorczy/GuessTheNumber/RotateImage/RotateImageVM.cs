using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.RotateImage
{
    public class RotateImageVM : ViewModelBase
    {
        private decimal rotateAngle;
        public decimal RotateAngle
        {
            get
            {
                return rotateAngle;
            }

            set
            {
                if (rotateAngle == value)
                {
                    return;
                }
                rotateAngle = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand rotateCommand;
        public RelayCommand RotateCommand
        {
            get
            {
                return rotateCommand
                    ?? (rotateCommand = new RelayCommand(
                    () =>
                    {
                        RotateAngle = RotateAngle + 5;
                    }));
            }
        }

    }
}
