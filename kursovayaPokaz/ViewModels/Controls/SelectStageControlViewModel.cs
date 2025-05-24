using kursovayaPokaz.Models;
using System.Collections.Generic;
using System.Windows.Input;
using kursovayaPokaz.Services.EventNotificator;
using kursovayaPokaz.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using kursovayaPokaz.Commands;
using System.Collections.ObjectModel;

namespace kursovayaPokaz.ViewModels.Controls
{
    class SelectStageControlViewModel : ViewModel
    {
        #region Fields
        private bool _IsCorrectFile;
        public bool IsCorrectFile { get => _IsCorrectFile; set => Set(ref _IsCorrectFile, value); }

        private Dictionary<string, DeserializationModel> ParsedModelForFisrtTable;

        private Dictionary<string, FirstTableModel> FirstTableModel;
        #endregion


        #region Command : FirstStage
        public ICommand CalculateFirstStageCommand { get; }
        private void OnCalculateFirstStageExecuted(object p)
        {
            

        }
        private bool CanCalculateFirstStageExecute(object p) => true;
        #endregion
        private void OnProgramStatusChanged(object? sender, bool e)
        {
            IsCorrectFile = e ? true : false;
        }
        private void OnDataParsed(object? sender, Dictionary<string, DeserializationModel> e)
        {
            ParsedModelForFisrtTable = new Dictionary<string, DeserializationModel>(e);          
        }

        public SelectStageControlViewModel() 
        {
            CalculateFirstStageCommand = new LambdaCommand(OnCalculateFirstStageExecuted, CanCalculateFirstStageExecute);
            App.services.GetRequiredService<IEventNotification>().ProgramStatusChanged += OnProgramStatusChanged;
            App.services.GetRequiredService<IEventNotification>().DataParsed += OnDataParsed;
        }

    }
}
