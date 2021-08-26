using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuessTheNumber.DialogWindow;

namespace GuessTheNumber.Saper.Game
{
    public class SaperPlayingFieldVM
    {
        public SaperPlayingFieldVM(string name, int row, int column)
        {
            Name = name;
            Row = row;
            Column = column;
        }
        public string Name { get; set; }


        public int Column { get; set; }
        public int Row { get; set; }

        private RelayCommand<Type> fieldCommand;
        public RelayCommand<Type> FieldCommand
        {
            get
            {
                return fieldCommand
                    ?? (fieldCommand = new RelayCommand<Type>(
                    (o) =>
                    {
                        var dlgObj = Activator.CreateInstance(o) as IDialogWindow;
                        dlgObj?.ExecuteInfoDialog(null, "" + Column + "," + Row);
                    }));
            }
        }
    }
}
