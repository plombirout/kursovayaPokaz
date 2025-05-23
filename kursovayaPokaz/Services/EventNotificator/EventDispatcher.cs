using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services.EventNotificator
{
    class EventDispatcher : IEventNotification
    {
        public event EventHandler<string> FileStatusChanged;

        public void Invoke(string name, params object[] args)
        {
            if (GetType().GetField(name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this) is not MulticastDelegate md) return;

            foreach (var d in md.GetInvocationList())
                d.Method.Invoke(d.Target, args);
        }
    }
}
