using kursovayaPokaz.Models;
using System.Collections.Generic;


namespace kursovayaPokaz.Services.ParsingServices
{
    interface IParsingService
    {
        public bool Parse(string input, out IDictionary<string, DeserializationModel> indicates);
    }

}
