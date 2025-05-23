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

            [JsonProperty("31.12.2022")]
            public double Value2022 { get; set; }

            [JsonProperty("31.12.2023")]
            public double Value2023 { get; set; }
        
    }
}
