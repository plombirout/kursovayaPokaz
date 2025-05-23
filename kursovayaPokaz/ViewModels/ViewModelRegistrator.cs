using kursovayaPokaz.Services.ExcelSerializer;
using kursovayaPokaz.ViewModels.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.ViewModels
{
     static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel >()
            .AddSingleton<TableViewControlViewModel>()
            .AddSingleton<FirstStageTableViewModel>()
            .AddSingleton<ToolBarControlViewModel>()
            .AddSingleton<SelectStageControlViewModel>();
    }
}
