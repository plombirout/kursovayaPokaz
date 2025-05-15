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
    internal class MainIndicatesParsingService : IParsingService
    {

        public bool Parse(string input, out IDictionary<string, ExcelData> indicates)
        {
            List<MainIndicator> data = null;
            indicates = null;
            try
            {
                data = JsonConvert.DeserializeObject<List<MainIndicator>>(input);

            }
            catch (Exception ex) { return false; }

            indicates= new Dictionary<string, ExcelData>
            {
                ["ProductionVolume"] = (ExcelData)data[0],
                ["WorkerProductivity"] = (ExcelData)data[1],
                ["WorkersCount"] = (ExcelData)data[2],
                ["FixedAssetsValue"] = (ExcelData)data[3],
                ["AssetsEfficiency"] = (ExcelData)data[4],
                ["Revenue"] = (ExcelData)data[5],
                ["Cost"] = (ExcelData)data[6],
                ["OperatingProfit"] = (ExcelData)data[7],
                ["ReportPeriodProfit"] = (ExcelData)data[8],
                ["NetProfit"] = (ExcelData)data[9],
                ["ProductProfitability"] = (ExcelData)data[10],
                ["SalaryFund"] = (ExcelData)data[11],
                ["AvgSalary"] = (ExcelData)data[12],
                ["LiquidityRatio"] = (ExcelData)data[13],
                ["OwnWorkingCapital"] = (ExcelData)data[14],
                ["ShortTermAssets"] = (ExcelData)data[15],
                ["ShortTermLiabilities"] = (ExcelData)data[16],
                ["LongTermAssets"] = (ExcelData)data[17],
                ["Equity"] = (ExcelData)data[18],
                ["LongTermLiabilities"] = (ExcelData)data[19]
            };
            return true;
        }

    }
}
