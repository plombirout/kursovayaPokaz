using kursovayaPokaz.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace kursovayaPokaz.ViewModels.Controls
{
    class TableViewControlViewModel : ViewModel
    {
        private Control _CurrentTable;
        public Control CurrentTable { get => _CurrentTable; set => Set(ref _CurrentTable, value); }
        public TableViewControlViewModel()
        {
            CurrentTable = new Views.Controls.Tables.FirstStageTableControl();
            CurrentTable.DataContext = new FirstStageTableViewModel();

        }
    }
}
