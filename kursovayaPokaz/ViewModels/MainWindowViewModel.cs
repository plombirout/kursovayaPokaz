using DocumentFormat.OpenXml.Wordprocessing;
using kursovayaPokaz.Commands;
using kursovayaPokaz.Models;
using kursovayaPokaz.Services.EventNotificator;
using kursovayaPokaz.Services.ExcelSerializer;
using kursovayaPokaz.Services.ParsingServices;
using kursovayaPokaz.Services.UserDialog;
using kursovayaPokaz.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kursovayaPokaz.ViewModels
{
   

    class MainWindowViewModel : ViewModel
    {
        #region Fields    
        
        #region Title : string - Window title
        private string _Title = "Выполнил: Зайцев Артем Денисович, студент группы ИСИТ-221";
        public string Title { get => _Title; set => Set(ref _Title, value); }


        private string _SelectedFile = "File not selected";
        public string SelectedFile { get => _SelectedFile; set => Set(ref _SelectedFile, value); }


        private IUserDialog _UserDialog;
        private IEventNotification _EventHandler;
        #endregion


        #endregion

        #region Command : OpenFileCommannd
        public ICommand OpenFileCommand { get; }
        private void OnOpenFileExecuted(object p)
        {
            if (!_UserDialog.OpenFile("Select excel file"))
                return;

            var res = _UserDialog.GetExcelFilePath(out string file);
            SelectedFile = file;
            if (!res) 
            {            
                _EventHandler.Invoke(nameof(IEventNotification.ProgramStatusChanged), this, false);
                return;
            }

            /// вот типа так
            IExcelSerializer serializer = new ExcelSerializerService();
            var serialized = serializer.ConvertExcelToJson(SelectedFile);

            //f tot njxytt enen
            bool resultOfDeserialization = false;
            try 
            {
                resultOfDeserialization = App.services.GetRequiredService<IParsingService>().Parse(serialized, out IDictionary<string, DeserializationModel> indicates);
            }
            catch(Exception ex) 
            {
                _EventHandler.Invoke(nameof(IEventNotification.ProgramStatusChanged), this, false);
                return;
            }

            //var tt = indicates.TryGetValue("Объем произведенной продукции (работ, услуг) в текущих ценах, тыс. р.", out DeserializationModel excelData);

            /// точнее ткт
            _EventHandler.Invoke(nameof(IEventNotification.FileStatusChanged), this, SelectedFile);
            _EventHandler.Invoke(nameof(IEventNotification.ProgramStatusChanged), this, true);

            ///Тут вызываешь парсерр
            /// иди нахуй и соси яйца >-)


        }
        private bool CanOpenFileExecute(object p) => true;
        #endregion
        public MainWindowViewModel()
        {
            _EventHandler = App.services.GetRequiredService<IEventNotification>();
            _UserDialog = App.services.GetRequiredService<IUserDialog>();
            OpenFileCommand = new LambdaCommand(OnOpenFileExecuted, CanOpenFileExecute);
        }




    }

}
