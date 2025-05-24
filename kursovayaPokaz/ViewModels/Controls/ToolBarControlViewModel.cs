using kursovayaPokaz.Services.EventNotificator;
using kursovayaPokaz.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;


namespace kursovayaPokaz.ViewModels.Controls
{
    class ToolBarControlViewModel : ViewModel
    {
        #region Fields
        private string _SelectedFile = "File not selected";
        public string SelectedFile { get => _SelectedFile; set => Set(ref _SelectedFile, value); }

        private bool _IsCorrectFile = false;
        public bool IsCorrectFile { get => _IsCorrectFile; set => Set(ref _IsCorrectFile, value); }

        private IEventNotification _EventHandler;
        #endregion

        private void OnFileStatusChanged(object? sender, string e)
        {
            if (e is null)
                return;

            SelectedFile = "Selected file: " + Path.GetFileName(e);
        }
        private void OnProgramStatusChanged(object? sender, bool e)
        {
            if (!e) 
            {
                IsCorrectFile = false;
                SelectedFile = "Wrong file";
            }
            else 
            {
                IsCorrectFile = true;
            }
        }

        public ToolBarControlViewModel()
        {

            IEventNotification _EventHandler = _EventHandler = App.services.GetRequiredService<IEventNotification>();
            App.services.GetRequiredService<IEventNotification>().ProgramStatusChanged += OnProgramStatusChanged;
            App.services.GetRequiredService<IEventNotification>().FileStatusChanged += OnFileStatusChanged;
        }

    }



}
