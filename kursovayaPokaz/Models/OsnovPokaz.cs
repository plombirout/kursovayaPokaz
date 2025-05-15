using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Models
{
    class OsnovPokaz
    {
        public double ObemProizvedennoiProdukcii { get; set; } // Объем произведенной продукции в текущем году (работ, услуг) в денежном выражении на 1 работника, тыс. р.
        public double SrednegodovayaViruchka { get; set; } // Среднегодовая выручка на 1 работника, тыс. р.
        public double SrednespisochnayaChislennost { get; set; } // Среднесписочная численность работников, чел.
        public double SrednegodovayaStoimost { get; set; } // Среднегодовая стоимость основных средств, тыс. р.
        public double FondArm { get; set; } // Фондоотдача основных средств, р./р.
        public double ViruchkaOtRealizacii { get; set; } // Выручка от реализации товаров, продукции, работ, услуг, тыс. р.
        public double TovarniyProizvoditel { get; set; } // Удельный вес товарных, подлежащих реализации товаров, продукции, работ, услуг, тыс. р.
        public double ViruchkaOtUchetnegoPerioda { get; set; } // Выручка от отчетного периода, тыс. р.
        public double PribilOtUchetnegoPerioda { get; set; } // Прибыль от отчетного периода, тыс. р.
        public double ChistayaPribil { get; set; } // Чистая прибыль, тыс. р.
        public double RentabelnostProdukcii { get; set; } // Рентабельность продукции, %
        public double RoniZarabotnoiPlati { get; set; } // Фонд заработной платы, тыс. р.
        public double SrednemesZarabotnayaPlata { get; set; } // Среднемесячная заработная плата, р.
        public double KoeffitsientObespechennosti { get; set; } // Коэффициент обеспеченности собственными оборотными средствами на конец года
        public double KoeffitsientOborotnihSredstv { get; set; } // Коэффициент оборотных средств на конец года
        public double AktiviItogo { get; set; } // Итоги. АКТИВЫ. Итого
        public double VKratkosrochnieObyazatelstva { get; set; } // В.к. КРАТКОСРОЧНЫЕ ОБЯЗАТЕЛЬСТВА
        public double DolgItogoAktiv { get; set; } // Ит. долгосрочные активы
        public double IVSobstvenniyKapital { get; set; } // Ит. СОБСТВЕННЫЙ КАПИТАЛ
        public double IVDolgosrochnieObyazatelstva { get; set; } // Ит. ДОЛГОСРОЧНЫЕ ОБЯЗАТЕЛЬСТВА


        public string Date { get; set; }

        public static void Parse(string put, out List<OsnovPokaz> osnovPokaz)
        {
            osnovPokaz = null;
            string filePath = "C:\\Users\\37529\\Downloads\\Telegram Desktop\\Курсовая показатели.xlsx"; // Путь к вашему Excel-файлу
            var dataList = new List<OsnovPokaz>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1); // Первый лист
                var columns = worksheet.ColumnsUsed();
                // var rows = worksheet.RowsUsed();

                // Пропускаем первую строку (заголовок "Показатели")
                bool isFirstColumn = true;


                foreach (var column in columns)
                {
                    if (isFirstColumn)
                    {
                        isFirstColumn = false;

                        continue; // Пропускаем заголовок

                    }

                    var data = new OsnovPokaz
                    {
                        Date = column.Cell(1).GetString(),
                        ObemProizvedennoiProdukcii = column.Cell(2).GetDouble(),
                        SrednespisochnayaChislennost = column.Cell(4).GetDouble(),
                        SrednegodovayaStoimost = column.Cell(5).GetDouble(),
                        FondArm = column.Cell(6).GetDouble(),
                        ViruchkaOtRealizacii = column.Cell(7).GetDouble(),
                        TovarniyProizvoditel = column.Cell(8).GetDouble(),
                        ViruchkaOtUchetnegoPerioda = column.Cell(9).GetDouble(),
                        PribilOtUchetnegoPerioda = column.Cell(10).GetDouble(),
                        ChistayaPribil = column.Cell(11).GetDouble(),
                        RentabelnostProdukcii = column.Cell(12).GetDouble(),
                        RoniZarabotnoiPlati = column.Cell(13).GetDouble(),
                        SrednemesZarabotnayaPlata = column.Cell(14).GetDouble(),
                        KoeffitsientObespechennosti = column.Cell(15).GetDouble(),
                        KoeffitsientOborotnihSredstv = column.Cell(16).GetDouble(),
                        AktiviItogo = column.Cell(17).GetDouble(),
                        VKratkosrochnieObyazatelstva = column.Cell(18).GetDouble(),
                        DolgItogoAktiv = column.Cell(19).GetDouble(),
                        IVSobstvenniyKapital = column.Cell(20).GetDouble(),
                        IVDolgosrochnieObyazatelstva = column.Cell(21).GetDouble()
                    };
                    data.SrednegodovayaViruchka = data.ObemProizvedennoiProdukcii / data.SrednespisochnayaChislennost;
                    dataList.Add(data);


                }
                osnovPokaz = new List<OsnovPokaz>(dataList);
            }
        }
    }
}