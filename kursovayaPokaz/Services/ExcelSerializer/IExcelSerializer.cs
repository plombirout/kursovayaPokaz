using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.ExcelSerializer
{
    internal interface IExcelSerializer
    {
        public string ConvertExcelToJson(string filePath, string sheetName = null);
           
    }
}
