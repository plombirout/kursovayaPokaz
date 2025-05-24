using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.EventNotificator
{
    interface IEventNotification
    {
        event EventHandler<string> FileStatusChanged;
        event EventHandler<bool> ProgramStatusChanged;
        void Invoke(string name, params object[] args);
    }
}
