using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.UserDialog
{
    interface IUserDialog
    {

        bool GetExcelFilePath(out string filePath);

        bool OpenFile(string title, string filter = "все файлы (*.*)|*.*");
    }
    
}
