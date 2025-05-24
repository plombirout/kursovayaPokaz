using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using kursovayaPokaz.Models;

namespace kursovayaPokaz.Services.EventNotificator
{
    interface IEventNotification
    {
        event EventHandler<string> FileStatusChanged;
        event EventHandler<bool> ProgramStatusChanged;
        event EventHandler<Dictionary<string, DeserializationModel>> DataParsed;
        void Invoke(string name, params object[] args);
    }
}
