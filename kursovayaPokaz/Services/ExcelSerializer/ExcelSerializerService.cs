using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.ExcelSerializer
{
    internal class ExcelSerializerService : IExcelSerializer
    {
        public string ConvertExcelToJson(string filePath, string sheetName = null)
        {
            // Проверка существования файла
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Excel-файл не найден");

            FileInfo fileInfo = new FileInfo(filePath);

            //ExcelPackage.License;
            EPPlusLicense license = new EPPlusLicense();
            license.SetNonCommercialPersonal("тунтунтунсахур");

            // Настройка контекста лицензии EPPlus       

            using (var package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet;

                // Получение указанного листа или первого листа
                if (!string.IsNullOrEmpty(sheetName))
                {
                    worksheet = package.Workbook.Worksheets[sheetName];
                    if (worksheet == null)
                        throw new ArgumentException($"Лист с именем '{sheetName}' не найден");
                }
                else
                {
                    worksheet = package.Workbook.Worksheets[0];
                    if (worksheet == null)
                        throw new Exception("В файле нет ни одного листа");
                }

                // Определение диапазона данных
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                if (rowCount < 2 || colCount < 1)
                    throw new Exception("В листе нет данных для конвертации");

                // Получение заголовков столбцов
                var headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    
                    var header = worksheet.Cells[1, col].Text;
                    if (worksheet.Cells[1, col].IsEmpty())
                        continue;
                    headers.Add(string.IsNullOrEmpty(header) ? $"Column{col}" : header);
                }
                colCount = headers.Count;

                // Сбор данных
                var data = new List<Dictionary<string, object>>();

                for (int row = 2; row <= rowCount; row++)
                {
                    var rowData = new Dictionary<string, object>();

                    for (int col = 1; col <= colCount; col++)
                    {
                        var cell = worksheet.Cells[row, col];

                        // Определение типа данных ячейки
                        if (cell.Value is DateTime)
                            rowData[headers[col - 1]] = cell.GetValue<DateTime>();
                        else if (cell.Value is double || cell.Value is decimal)
                        { rowData[headers[col - 1]] = cell.GetValue<double>(); }
                        else if (cell.Value is bool)
                            rowData[headers[col - 1]] = cell.GetValue<bool>();
                        else
                            rowData[headers[col - 1]] = cell.Text;
                    }

                    data.Add(rowData);
                }

                // Сериализация в JSON с форматированием
                return JsonConvert.SerializeObject(data, Formatting.Indented);
            }
        }

    }
}
