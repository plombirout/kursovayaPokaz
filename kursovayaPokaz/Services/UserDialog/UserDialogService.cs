
using Microsoft.Win32;

namespace kursovayaPokaz.Services.UserDialog
{
    class UserDialogService : IUserDialog
    {
        public string SelectedFile { get; private set; }

        public bool GetExcelFilePath(out string filePath)
        {
            filePath = "Incorrect file";
            if (SelectedFile != null && SelectedFile.Contains(".xlsx"))
            {
                filePath = SelectedFile;
                return true;
            }
            return false;

        }

        public bool OpenFile(string title, string filter = "все файлы (*.*)|*.*")
        {
            var file_dialog = new OpenFileDialog { Title = title, Filter = filter };
            if (file_dialog.ShowDialog() != true)
            {
                SelectedFile = null;
                return false;

            }

            SelectedFile = file_dialog.FileName;
            return true;
        }
    }
}
