using GalaSoft.MvvmLight;
using GuessTheNumber.Saper.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.Saper.Game
{
    class SaperVM : ViewModelBase
    {
        public SaperVM()
        {
            RowCount = SaperSettings.RowCount;
            ColCount = SaperSettings.ColCount;
            Board = new ObservableCollection<SaperPlayingFieldVM>();
            for (int row= 0; row< RowCount; row++)
                for (int col= 0; col< ColCount; col++)
                    Board.Add(new SaperPlayingFieldVM("" + col + "," + row, row, col));
        }

        public ObservableCollection<SaperPlayingFieldVM> Board { get; set; }

        public int RowCount { get; set; }

        public int ColCount { get; set; }
    }
}
