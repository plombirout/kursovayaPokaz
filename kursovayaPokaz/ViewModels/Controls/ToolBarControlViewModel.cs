using kursovayaPokaz.Services.EventNotificator;
using kursovayaPokaz.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaPokaz.ViewModels.Controls
{
    class ToolBarControlViewModel : ViewModel
    {
        private string _SelectedFile = "File not selected";
        public string SelectedFile { get => _SelectedFile; set => Set(ref _SelectedFile, value); }



        public ToolBarControlViewModel() {
            App.services.GetRequiredService<IEventNotification>().FileStatusChanged += OnFileStatusChanged;
        }

        private void OnFileStatusChanged(object? sender, string e)
        {
            if (e != null)
                SelectedFile = e;
        }
    }



}
