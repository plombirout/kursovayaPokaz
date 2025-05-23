using kursovayaPokaz.ViewModels.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.ViewModels
{
   internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.services.GetRequiredService<MainWindowViewModel>();
        public FirstStageTableViewModel FirstStageTableModel => App.services.GetRequiredService<FirstStageTableViewModel>();
        public TableViewControlViewModel TableViewControlModel => App.services.GetRequiredService<TableViewControlViewModel>();
        public ToolBarControlViewModel ToolBarControlModel => App.services.GetRequiredService<ToolBarControlViewModel>();
        public SelectStageControlViewModel SelectStageControlModel => App.services.GetRequiredService<SelectStageControlViewModel>();

    }
}
