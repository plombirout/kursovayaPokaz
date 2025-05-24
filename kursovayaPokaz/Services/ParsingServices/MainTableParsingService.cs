using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using kursovayaPokaz.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.ParsingServices
{
    internal class MainTableParsingService : IParsingService
    {
        public bool Parse(string input, out IDictionary<string, DeserializationModel> indicates)
        {
            List<DeserializationModel> data = null;
            indicates = null;
            try
            {
                data = JsonConvert.DeserializeObject<List<DeserializationModel>>(input);

            }
            catch (Exception ex) { return false; }

            indicates = new Dictionary<string, DeserializationModel>
            {
                ["Объем произведенной продукции (работ, услуг) в текущих ценах, тыс. р."] = data[0],
                //["Среднегодовая выработка на 1 работника, тыс. р."] = data[1],
                ["Среднесписочная численность работников, чел"] = data[2],
                ["Среднегодовая стоимость основных средств, тыс. р."] = data[3],
                //["Фондоотдача основных средств, р./р."] = data[4],
                [" Выручка от реализации товаров, работ, услуг, тыс. р."] = data[5],
                [" Себестоимость реализованных товаров, продукции, работ, услуг, тыс. р."] = data[6],
                [" Прибыль от реализации товаров, работ, услуг, тыс. р."] = data[7],
                ["Прибыль отчетного периода, тыс. р."] = data[8],
                ["Чистая прибыль, тыс. р."] = data[9],
                //[" Рентабельность продукции, %"] = data[10],
                ["Фонд заработной платы, тыс. р."] = data[11],
                ["Среднемесячная заработная плата, р."] = data[12],
                //["Коэффициент текущей ликвидности на конец года"] = data[13],
                //["Коэффициент обеспеченности собственными оборотными средствами на конец года"] = data[14],
                ["КРАТКОСРОЧНЫЕ АКТИВЫ. "] = data[15],
                ["КРАТКОСРОЧНЫЕ ОБЯЗАТЕЛЬСТВА. "] = data[16],
                ["ДОЛГОСРОЧНЫЕ АКТИВЫ"] = data[17],
                ["СОБСТВЕННЫЙ КАПИТАЛ"] = data[18],
                ["ДОЛГОСРОЧНЫЕ ОБЯЗАТЕЛЬСТВА"] = data[19],
                //["Краткосрочная кредиторская задолженность (тыс. руб.)"] = data[20],
                ["В том числе: поставщикам, подрядчикам, исполнителям"] = data[21],
                ["по авансам полученным"] = data[22],
                ["по налогам и сборам"] = data[23],
                ["по соц. страхованию и обеспечению"] = data[24],
                ["по оплате труда"] = data[25],
                ["по лизинговым платежам"] = data[26],
                ["собственнику имущества"] = data[27],
                ["прочим кредиторам"] = data[28],
                //["Краткосрочная дебиторская задолженность (тыс. руб.)"] = data[29],
                ["В том числе: расчеты с покупателями и заказчиками"] = data[30],
                ["расчеты с поставщиками и заказчиками (авансы выданные, предоплата)"] = data[31],
                ["расчеты с бюджетом"] = data[32],
                ["расчеты по соц. страхованию и обеспечению"] = data[33],
                ["прочая дебиторская задолженность"] = data[34],
                ["Общая сумма дебиторской задолженности"] = data[35],
                ["Общая сумма кредиторской задолженности"] = data[36],
                //["Соотношение кредиторской и дебиторской задолженности"] = data[37],
                ["Кредиторская задолженность на начало года, тыс. р."] = data[38],
                ["Кредиторская задолженность на конец года, тыс. р."] = data[39],
                //["Среднегодовая кредиторская задолженность (тыс. руб.)"] = data[40],
                //["Коэффициент оборачиваемости кредиторской задолженности (тыс. р.) (К об)"] = data[41],
                //["Длительность одного оборота кредиторской задолженности (тыс. р.) (ДО)"] = data[42],
                ["Дебиторская задолженность на начало года, тыс. р."] = data[43],
                ["Дебиторская задолженность на конец года, тыс. р."] = data[44],
                //["Среднегодовая дебиторская задолженность (тыс. р.)"] = data[45],
                //["Коэффициент оборачиваемости дебиторской задолженности (тыс. р.) (К об)"] = data[46],
                //["Длительность одного оборота дебиторской задолженности (тыс. р.) (ДО)"] = data[47],
                ["Кредиторская задолженность, тыс. р."] = data[48],
                ["Дебиторская задолженность, тыс. р."] = data[49],
                //["Превышение дебиторской задолженности над кредиторской задолженностью в абсолютной сумме, тыс. р.;"] = data[50],
                //["в процентах, %"] = data[51],
                ["Денежные средства: остаток, тыс. р."] = data[52],
                //["Покрытие в абсолютной сумме остатков кредиторской задолженности денежными средствами,  тыс. р."] = data[53]
            };

            DeserializationModel? val1 = null, val2 = null, val3 = null, val4 = null, val5 = null, val6 = null, val7 = null, val8 = null;



            var AverageAnnualOutputPerEmployee = new DeserializationModel();
            AverageAnnualOutputPerEmployee.Indicator = " Среднегодовая выработка на 1 работника, тыс. р. ";
            indicates.TryGetValue("Объем произведенной продукции (работ, услуг) в текущих ценах, тыс. р.", out val1);
            indicates.TryGetValue("Среднесписочная численность работников, чел", out val2);
            AverageAnnualOutputPerEmployee.Year2022 = (val1.Year2022 ?? 0) / (val2.Year2022 ?? 0);
            AverageAnnualOutputPerEmployee.Year2023 = (val1.Year2023 ?? 0) / (val2.Year2023 ?? 0);
            indicates.Add("Среднегодовая выработка на 1 работника, тыс. р.", AverageAnnualOutputPerEmployee);


            var ReturnOnFixedAssets = new DeserializationModel();
            ReturnOnFixedAssets.Indicator = "Фондоотдача основных средств, р./р.";
            indicates.TryGetValue(" Выручка от реализации товаров, работ, услуг, тыс. р.", out val1);
            indicates.TryGetValue("Среднегодовая стоимость основных средств, тыс. р.", out val2);
            ReturnOnFixedAssets.Year2022 = (val1.Year2022 ?? 0) / (val2.Year2022 ?? 0);
            ReturnOnFixedAssets.Year2023 = (val1.Year2023 ?? 0) / (val2.Year2023 ?? 0);


            var ProductProfitability = new DeserializationModel();
            ProductProfitability.Indicator = " Рентабельность продукции, %";
            indicates.TryGetValue(" Прибыль от реализации товаров, работ, услуг, тыс. р.", out val1);
            indicates.TryGetValue(" Себестоимость реализованных товаров, продукции, работ, услуг, тыс. р.", out val2);
            ProductProfitability.Year2022 = (val1.Year2022 ?? 0) / (val2.Year2022 ?? 0) * 100;
            ProductProfitability.Year2023 = (val1.Year2023 ?? 0) / (val2.Year2023 ?? 0) * 100;

            var CurrentRatioAtTheEndOfTheYear = new DeserializationModel();
            CurrentRatioAtTheEndOfTheYear.Indicator = "Коэффициент текущей ликвидности на конец года";
            indicates.TryGetValue("КРАТКОСРОЧНЫЕ АКТИВЫ. ", out val1);
            indicates.TryGetValue("КРАТКОСРОЧНЫЕ ОБЯЗАТЕЛЬСТВА. ", out val2);
            CurrentRatioAtTheEndOfTheYear.Year2022 = (val1.Year2022 ?? 0) / (val2.Year2022 ?? 0);
            CurrentRatioAtTheEndOfTheYear.Year2023 = (val1.Year2023 ?? 0) / (val2.Year2023 ?? 0);

            var RatioOfOwnWorkingCapitalAtTheEndOfTheYear = new DeserializationModel();
            RatioOfOwnWorkingCapitalAtTheEndOfTheYear.Indicator = "Коэффициент обеспеченности собственными оборотными средствами на конец года";
            indicates.TryGetValue("СОБСТВЕННЫЙ КАПИТАЛ", out val1);
            indicates.TryGetValue("ДОЛГОСРОЧНЫЕ ОБЯЗАТЕЛЬСТВА", out val2);
            indicates.TryGetValue("ДОЛГОСРОЧНЫЕ АКТИВЫ", out val3);
            indicates.TryGetValue("КРАТКОСРОЧНЫЕ АКТИВЫ. ", out val4);
            RatioOfOwnWorkingCapitalAtTheEndOfTheYear.Year2022 =
                ((val1.Year2022 ?? 0) +
                (val2.Year2022 ?? 0) -
                (val3.Year2022 ?? 0)) /
                (val4.Year2022 ?? 0);
            RatioOfOwnWorkingCapitalAtTheEndOfTheYear.Year2023 =
                ((val1.Year2023 ?? 0) +
                (val2.Year2023 ?? 0) -
                (val3.Year2023 ?? 0)) /
                (val4.Year2023 ?? 0);


            var CurrentAccountsPayable = new DeserializationModel();
            CurrentAccountsPayable.Indicator = "Краткосрочная кредиторская задолженность (тыс. руб.)";
            indicates.TryGetValue("В том числе: поставщикам, подрядчикам, исполнителям", out val1);
            indicates.TryGetValue("по авансам полученным", out val2);
            indicates.TryGetValue("по налогам и сборам", out val3);
            indicates.TryGetValue("по соц. страхованию и обеспечению", out val4);
            indicates.TryGetValue("по оплате труда", out val5);
            indicates.TryGetValue("по лизинговым платежам", out val6);
            indicates.TryGetValue("собственнику имущества", out val7);
            indicates.TryGetValue("прочим кредиторам", out val8);
            CurrentAccountsPayable.Year2022 =
    (val1.Year2022 ?? 0) +
    (val2.Year2022 ?? 0) +
    (val3.Year2022 ?? 0) +
    (val4.Year2022 ?? 0) +
    (val5.Year2022 ?? 0) +
    (val6.Year2022 ?? 0) +
    (val7.Year2022 ?? 0) +
    (val8.Year2022 ?? 0);
            CurrentAccountsPayable.Year2023 =
    (val1.Year2023 ?? 0) +
    (val2.Year2023 ?? 0) +
    (val3.Year2023 ?? 0) +
    (val4.Year2023 ?? 0) +
    (val5.Year2023 ?? 0) +
    (val6.Year2023 ?? 0) +
    (val7.Year2023 ?? 0) +
    (val8.Year2023 ?? 0);


            var CurrentAccountsReceivable = new DeserializationModel();
            CurrentAccountsReceivable.Indicator = "Краткосрочная дебиторская задолженность (тыс. руб.)";
            indicates.TryGetValue("В том числе: расчеты с покупателями и заказчиками", out val1);
            indicates.TryGetValue("расчеты с поставщиками и заказчиками (авансы выданные, предоплата)", out val2);
            indicates.TryGetValue("расчеты с бюджетом", out val3);
            indicates.TryGetValue("расчеты по соц. страхованию и обеспечению", out val4);
            indicates.TryGetValue("прочая дебиторская задолженность", out val5);
            CurrentAccountsReceivable.Year2022 =
    (val1.Year2022 ?? 0) +
    (val2.Year2022 ?? 0) +
    (val3.Year2022 ?? 0) +
    (val4.Year2022 ?? 0) +
    (val5.Year2022 ?? 0);

            CurrentAccountsReceivable.Year2023 =
                (val1.Year2023 ?? 0) +
    (val2.Year2023 ?? 0) +
    (val3.Year2023 ?? 0) +
    (val4.Year2023 ?? 0) +
    (val5.Year2023 ?? 0);

            var AccountsPayableToAccountsReceivableRatio = new DeserializationModel();
            AccountsPayableToAccountsReceivableRatio.Indicator = "Соотношение кредиторской и дебиторской задолженности";
            AccountsPayableToAccountsReceivableRatio.Year2022 = CurrentAccountsPayable.Year2022 / CurrentAccountsReceivable.Year2022 * 100;
            AccountsPayableToAccountsReceivableRatio.Year2023 = CurrentAccountsPayable.Year2023 / CurrentAccountsReceivable.Year2023 * 100;


            var AverageAnnualAccountsPayable = new DeserializationModel();
            AverageAnnualAccountsPayable.Indicator = "Среднегодовая кредиторская задолженность (тыс. руб.)";
            indicates.TryGetValue("Кредиторская задолженность на начало года, тыс. р.", out val1);
            indicates.TryGetValue("Кредиторская задолженность на конец года, тыс. р.", out val2);
            AverageAnnualAccountsPayable.Year2022 = ((val1.Year2022 ?? 0) + (val2.Year2022 ?? 0)) / 2;
            AverageAnnualAccountsPayable.Year2023 = ((val1.Year2023 ?? 0) + (val2.Year2023 ?? 0)) / 2;

            var AccountsPayableTurnoverRatio = new DeserializationModel();
            AccountsPayableTurnoverRatio.Indicator = "Коэффициент оборачиваемости кредиторской задолженности (тыс. р.) (К об)";
            indicates.TryGetValue(" Выручка от реализации товаров, работ, услуг, тыс. р.", out val1);
            AccountsPayableTurnoverRatio.Year2022 = (val1.Year2022 ?? 0) / AverageAnnualAccountsPayable.Year2022;
            AccountsPayableTurnoverRatio.Year2023 = (val1.Year2023 ?? 0) / AverageAnnualAccountsPayable.Year2023;

            var DurationOfOneTurnoverOfAccountsPayable = new DeserializationModel();
            DurationOfOneTurnoverOfAccountsPayable.Indicator = "Длительность одного оборота кредиторской задолженности (тыс. р.) (ДО)";
            indicates.TryGetValue(" Выручка от реализации товаров, работ, услуг, тыс. р.", out val1);
            DurationOfOneTurnoverOfAccountsPayable.Year2022 = AverageAnnualAccountsPayable.Year2022 / (val1.Year2022 ?? 0) * 360;
            DurationOfOneTurnoverOfAccountsPayable.Year2023 = AverageAnnualAccountsPayable.Year2023 / (val1.Year2023 ?? 0) * 360;

            var AverageAnnualAccountsReceivable = new DeserializationModel();
            AverageAnnualAccountsReceivable.Indicator = "Среднегодовая дебиторская задолженность (тыс. р.)";
            indicates.TryGetValue("Дебиторская задолженность на начало года, тыс. р.", out val1);
            indicates.TryGetValue("Дебиторская задолженность на конец года, тыс. р.", out val2);
            AverageAnnualAccountsReceivable.Year2022 = ((val1.Year2022 ?? 0) + (val2.Year2022 ?? 0)) / 2;
            AverageAnnualAccountsReceivable.Year2023 = ((val1.Year2023 ?? 0) + (val2.Year2023 ?? 0)) / 2;



            var AccountsReceivableTurnoverRatio = new DeserializationModel();
            AccountsReceivableTurnoverRatio.Indicator = "Коэффициент оборачиваемости дебиторской задолженности (тыс. р.) (К об)";
            indicates.TryGetValue(" Выручка от реализации товаров, работ, услуг, тыс. р.", out val1);
            AccountsReceivableTurnoverRatio.Year2022 = (val1.Year2022 ?? 0) / AverageAnnualAccountsReceivable.Year2022;
            AccountsReceivableTurnoverRatio.Year2023 = (val1.Year2023 ?? 0) / AverageAnnualAccountsReceivable.Year2023;

            var DurationOfOneTurnoverOfAccountsReceivable = new DeserializationModel();
            DurationOfOneTurnoverOfAccountsReceivable.Indicator = "Длительность одного оборота дебиторской задолженности (тыс. р.) (ДО)";
            indicates.TryGetValue(" Выручка от реализации товаров, работ, услуг, тыс. р.", out val1);
            DurationOfOneTurnoverOfAccountsReceivable.Year2022 = AverageAnnualAccountsReceivable.Year2022 / (val1.Year2022 ?? 0) * 360;
            DurationOfOneTurnoverOfAccountsReceivable.Year2023 = AverageAnnualAccountsReceivable.Year2023 / (val1.Year2023 ?? 0) * 360;

            var ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmount = new DeserializationModel();
            ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmount.Indicator = "Превышение дебиторской задолженности над кредиторской задолженностью в абсолютной сумме, тыс. р.;";
            ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmount.Year2022 = CurrentAccountsReceivable.Year2022 - CurrentAccountsPayable.Year2022;
            ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmount.Year2023 = CurrentAccountsReceivable.Year2023 - CurrentAccountsPayable.Year2023;

            var ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmountAsAPercentage = new DeserializationModel();
            ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmountAsAPercentage.Indicator = "в процентах, %";
            ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmountAsAPercentage.Year2022 = CurrentAccountsReceivable.Year2022 / CurrentAccountsPayable.Year2022 * 100;
            ExcessOfAccountsEeceivableOverAccountsPayableInAbsoluteAmountAsAPercentage.Year2023 = CurrentAccountsReceivable.Year2023 / CurrentAccountsPayable.Year2023 * 100;

            var CoverageOfTheAbsoluteAmountOfAccountsPayableBalancesWithCash = new DeserializationModel();
            CoverageOfTheAbsoluteAmountOfAccountsPayableBalancesWithCash.Indicator = "Покрытие в абсолютной сумме остатков кредиторской задолженности денежными средствами,  тыс. р.";
            indicates.TryGetValue("Денежные средства: остаток, тыс. р.", out val1);
            CoverageOfTheAbsoluteAmountOfAccountsPayableBalancesWithCash.Year2022 = CurrentAccountsPayable.Year2022 - (val1.Year2022 ?? 0);
            CoverageOfTheAbsoluteAmountOfAccountsPayableBalancesWithCash.Year2023 = CurrentAccountsPayable.Year2023 - (val1.Year2023 ?? 0);
            return true;
        }
    }
}

