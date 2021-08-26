using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GuessTheNumber.DialogWindow;
using System;
using System.IO;

namespace GuessTheNumber.LoadFile
{
    public class LoadFileVM : ViewModelBase
    {
        private string filePath;
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                if (filePath == value)
                {
                    return;
                }
                filePath = value;
                RaisePropertyChanged();
            }
        }

        private string fileContent;
        public string FileContent
        {
            get
            {
                return fileContent;
            }
            set
            {
                if (fileContent == value)
                {
                    return;
                }
                fileContent = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand<Type> loadFile;
        public RelayCommand<Type> LoadFile
        {
            get
            {
                return loadFile
                    ?? (loadFile = new RelayCommand<Type>(
                    (o) =>
                    {
                        var dlgObj = Activator.CreateInstance(o) as IDialogWindow;
                        string fileName = "";
                        if (dlgObj?.ExecuteFileDialog(null, "Tekstowe|*.txt", out fileName) ?? false)
                        {
                            FilePath = fileName;
                            FileContent = File.ReadAllText(fileName);
                        }
                    }));
            }
        }

        private RelayCommand<Type> saveFile;
        public RelayCommand<Type> SaveFile
        {
            get
            {
                return saveFile
                    ?? (saveFile = new RelayCommand<Type>(
                    (o) =>
                    {
                        var dlgObj = Activator.CreateInstance(o) as IDialogWindow;
                        string fileName = "";
                        if (dlgObj?.ExecuteFileDialog(null, "Tekstowe|*.txt", out fileName) ?? false)
                        {
                            File.WriteAllText(fileName, FileContent);
                            FilePath = fileName;
                            //FileContent = File.ReadAllText(fileNames);
                        }
                    }));
            }
        }
    }
}
