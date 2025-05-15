using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Models
{
    class DinamCreditZad
    {
        class DolgKreditZad
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;

        }
        public string date;
        class KratkKreditZad
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;

        }
        class Params
        {
            public double summ;
            public double ves;
            public string date;
        }
        class Changes
        {
            public double summ;
            public double temp;
        }

        class VTomChisle
        {
            public Params paramsTwo;
            public Params paramsOne;
            public Changes changesOne;
        }

        class PoAvansamPoluchennim
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }


        class PoNalogamISboram
        {
            /// <summary>
            /// 
            /// </summary>
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }

        class CtraxIObespe4
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }
        class PoOplate
        {

            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }

        class Lizing
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }

        class Pro4im
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }
        class Itogo
        {
            public Params paramsOne;
            public Params ParamsTwo;
            public Changes changesOne;
        }


        public static void Parse(string put, out List<DinamCreditZad> dinamCreditZad)
        {

            dinamCreditZad = null;
            string filePath = "C:\\Users\\37529\\Desktop\\1.xlsx";
            var dataList = new List<DinamCreditZad>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(2);
                var columns = worksheet.ColumnsUsed();
                bool isFirstRow = true;
                var rows = worksheet.RowsUsed();
                int counter = 1;
                bool headerParsed = false;
                bool isDolgosrokParsed = false;
                bool isD = false;
                Params hfirst = new Params();
                Params hSecond = new Params();
                DolgKreditZad dolgKreditZad = new DolgKreditZad();


                foreach (var row in rows)
                {
                    if (counter < 2)
                    {
                        counter++;
                        continue;
                    }

                    if (!headerParsed)
                    {

                        hfirst.date = row.Cell(2).GetString();
                        hSecond.date = row.Cell(4).GetString();
                        headerParsed = true;
                        counter++;
                        continue;
                    }
                    if (counter < 4)
                    {
                        counter++;
                        continue;
                    }
                    if (!isDolgosrokParsed)
                    {
                        Params first = new Params();
                        first.summ = double.TryParse(row.Cell(2).GetString() ?? "", out double result) ? result : 0;
                        first.ves = double.TryParse(row.Cell(3).GetString() ?? "", out double result1) ? result1 : 0;
                        first.date = hfirst.date;
                        Params second = new Params();
                        second.summ = double.TryParse(row.Cell(4).GetString() ?? "", out double result2) ? result2 : 0;
                        first.ves = double.TryParse(row.Cell(5).GetString() ?? "", out double result3) ? result3 : 0;
                        second.date = hSecond.date;
                        dolgKreditZad.paramsOne = first;
                        dolgKreditZad.ParamsTwo = second;
                        isDolgosrokParsed = true;
                    }
                }
            }
        }
    }
}