using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuessTheNumber.DialogWindow
{
    class OpenFilesDialog : IDialogWindow
    {
        public bool ExecuteFileDialog(object owner, string extFilter, out string fileName)
        {
            fileName = "";
            var fd = new OpenFileDialog
            {
                Multiselect = false
            };
            if (!string.IsNullOrWhiteSpace(extFilter))
            {
                fd.Filter = extFilter;
            }
            if (fd.ShowDialog(owner as Window)??false)
            {
                fileName = fd.FileName;
                return true;
            }

            return false;
        }

        public void ExecuteInfoDialog(object owner, string message)
        {
            throw new NotImplementedException();
        }
    }

    class SaveFilesDialog : IDialogWindow
    {
        public bool ExecuteFileDialog(object owner, string extFilter, out string fileName)
        {
            fileName = "";
            var fd = new SaveFileDialog();
            if (!string.IsNullOrWhiteSpace(extFilter))
            {
                fd.Filter = extFilter;
            }
            if (fd.ShowDialog(owner as Window) ?? false)
            {
                fileName = fd.FileName;
                return true;
            }

            return false;
        }

        public void ExecuteInfoDialog(object owner, string message)
        {
            throw new NotImplementedException();
        }
    }

    class InfoDialog : IDialogWindow
    {
        public bool ExecuteFileDialog(object owner, string extFilter, out string fileName)
        {
            throw new NotImplementedException();
        }

        public void ExecuteInfoDialog(object owner, string message)
        {
            MessageBox.Show(message);
        }
    }
}
