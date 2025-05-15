using kursovayaPokaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.ParsingServices
{
    interface IParsingService
    {
        public bool Parse(string input, out IDictionary<string, ExcelData> indicates);
    }

}
