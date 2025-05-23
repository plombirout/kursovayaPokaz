using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.EventNotificator
{
    interface IEventNotification
    {
        event EventHandler<string> FileStatusChanged;
        void Invoke(string name, params object[] args);
    }
}
