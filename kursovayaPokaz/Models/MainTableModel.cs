using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Models
{
    internal class MainTableModel : ExcelData
    {
        [JsonProperty("Показатель")]
        public string SostavKreditZad { get; set; }

        [JsonProperty("2022")]
        public double ValueSummNach { get; set; }

        [JsonProperty("2023")]
        public double ValueVesNach { get; set; }
    }
}
