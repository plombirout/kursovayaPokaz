using System;
using kursovayaPokaz.Services.EventNotificator;
using kursovayaPokaz.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;

namespace kursovayaPokaz.ViewModels.Controls
{
    class SelectStageControlViewModel : ViewModel
    {
        #region Fields
        private bool _IsCorrectFile;
        public bool IsCorrectFile { get => _IsCorrectFile; set => Set(ref _IsCorrectFile, value); }
        #endregion


        private void OnProgramStatusChanged(object? sender, bool e)
        {
            IsCorrectFile = e ? true : false;
        }

        public SelectStageControlViewModel() 
        {
            App.services.GetRequiredService<IEventNotification>().ProgramStatusChanged += OnProgramStatusChanged;
        }

    }
}
