using kursovayaPokaz.Services.EventNotificator;
using kursovayaPokaz.Services.ExcelSerializer;
using kursovayaPokaz.Services.ParsingServices;
using kursovayaPokaz.Services.UserDialog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.Services
{
    static class ServiceRegistrator
    {
        public static IServiceCollection AddService(this IServiceCollection services) => services
            .AddSingleton<IExcelSerializer, ExcelSerializerService>()
            .AddSingleton<IUserDialog, UserDialogService>()
            .AddSingleton<IEventNotification, EventDispatcher>()
            .AddSingleton<IParsingService, MainTableParsingService>();
    }
}
