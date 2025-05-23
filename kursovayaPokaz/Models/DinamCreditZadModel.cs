using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace kursovayaPokaz.Models
{
    internal class DinamCreditZadModel : ExcelData
    {
        [JsonProperty("Состав кредиторской задолженности")]
        public string SostavKreditZad { get; set; }

        [JsonProperty("сумма, тыс. р. на начало")]
        public double ValueSummNach { get; set; }

        [JsonProperty("удельный вес, % на начало")]
        public double ValueVesNach { get; set; }

        [JsonProperty("сумма, тыс. р. на конец")]
        public double ValueSummKon { get; set; }

        [JsonProperty("удельный вес, % на конец")]
        public double ValueVesKon { get; set; }

        [JsonProperty("по сумме, тыс. р.")]
        public double ValueSumm { get; set; }

        [JsonProperty("темп прироста, %")]
        public double ValueVes { get; set; }
    }
}
//сумма, тыс. р. На начало    
//удельный вес, % На начало
//    сумма, тыс. р. На конец
//    сумма, тыс. р. На конец
//    по сумме, тыс. р.
//    темп прироста, %


   