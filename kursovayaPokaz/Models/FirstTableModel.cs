using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kursovayaPokaz.Models
{
    internal class FirstTableModel
    {
        public string Indicator { get; set; }
        public double? Year2022 { get; set; }
        public double? Year2023 { get; set; }
    }
}
