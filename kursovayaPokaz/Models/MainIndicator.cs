using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Models
{
    internal class MainIndicator : ExcelData
    {
    
        
            [JsonProperty("Показатель")]
            public string Indicator { get; set; }

            [JsonProperty("Начало")]
            public double Value2022 { get; set; }

            [JsonProperty("Конец")]
            public double Value2023 { get; set; }
        
    }
}
