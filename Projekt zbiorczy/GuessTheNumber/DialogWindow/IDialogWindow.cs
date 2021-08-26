using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber.DialogWindow
{
    public interface IDialogWindow
    {
        bool ExecuteFileDialog(object owner, string extFilter, out string fileName);
        void ExecuteInfoDialog(object owner, string message);
    }
}
