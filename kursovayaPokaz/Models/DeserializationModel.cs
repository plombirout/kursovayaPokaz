using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kursovayaPokaz.Models
{

    /// double? дабл с вопросом это типа когда ячейчка пустая в поле записывается налл а дабл вопрос это налбл тип типа может быть число и нал понял нах?

    internal class DeserializationModel
    {
        [JsonProperty("Показатель ")]
        public string Indicator { get; set; }

        [JsonProperty("2022")]
        public double? Year2022 { get; set; } 

        [JsonProperty("2023")]
        public double? Year2023 { get; set; }
    }
}
