using kursovayaPokaz.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.ParsingServices
{
    internal class KreditZad : IParsingService
    {
        public bool Parse(string input, out IDictionary<string, ExcelData> indicates)
        {
            List<DinamCreditZadModel> data = null;
            indicates = null;
            try
            {
                data = JsonConvert.DeserializeObject<List<DinamCreditZadModel>>(input);

            }
            catch (Exception ex) { return false; }
            indicates = new Dictionary<string, ExcelData>
            {
                ["Долгосрочная кредиторская задолженность"] = (ExcelData)data[1],
                ["Краткосрочная кредиторская задолженность "] = (ExcelData)data[2],
                ["В том числе: поставщикам, подрядчикам, исполнителям, "] = (ExcelData)data[3],
                ["по авансам полученным"] = (ExcelData)data[4],
                ["по налогам и сборам"] = (ExcelData)data[5],
                ["по соц. страхованию и обеспечению"] = (ExcelData)data[6],
                ["по оплате труда"] = (ExcelData)data[7],
                ["по лизинговым платежам"] = (ExcelData)data[8],
                ["собственнику имущества"] = (ExcelData)data[9],
                ["прочим кредиторам"] = (ExcelData)data[10],
                ["Итого кредиторская задолженность"] = (ExcelData)data[11]
            };
            return true;
        }

    }
}
