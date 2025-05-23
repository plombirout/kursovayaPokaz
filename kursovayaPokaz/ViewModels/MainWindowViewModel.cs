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
        #region File
        public ICommand OpenFileCommand { get; }

        private void OnOpenFileExecuted(object p)
        {
            if (!App.services.GetRequiredService<IUserDialog>().OpenFile(""))
            {
                return;
            }

            var res = App.services.GetRequiredService<IUserDialog>().GetExcelFilePath(out string file);
            SelectedFile = file;
            if (!res)
                return;

            App.services.GetRequiredService<IEventNotification>().Invoke(nameof(IEventNotification.FileStatusChanged), this, SelectedFile);
            IExcelSerializer serializer = new ExcelSerializerService();
            var a = serializer.ConvertExcelToJson(SelectedFile);
            IParsingService parser1 = new MainTable();
            var b = parser1.Parse(a, out IDictionary<string, ExcelData> indicates);
            var tt = indicates.TryGetValue("Объем произведенной продукции (работ, услуг) в текущих ценах, тыс. р.", out ExcelData excelData);
            var ttt = excelData as MainTableModel;
        }
        private bool CanOpenFileExecute(object p) => true;
        #endregion

        #region Title : string - Window title
        private string _Title = "Выполнил: Зайцев Артем Денисович, студент группы ИСИТ-221";
        public string Title { get => _Title; set => Set(ref _Title, value); }


        private string _SelectedFile = "File not selected";
        public string SelectedFile { get => _SelectedFile; set => Set(ref _SelectedFile, value); }




        private double _variable;
        public double variable { get => _variable; set => Set(ref _variable, value); }

        private double _variable1;
        public double variable1 { get => _variable1; set => Set(ref _variable1, value); }

        #endregion
        #region SwitchReceivingMode
        public ICommand SwitchReceivingModeCommand { get; }

        private void OnSwitchReceivingModeExecuted(object p)
        {
            //osnovpokaz.parse(null, out list<osnovpokaz> osnovpokaz);
            //variable = osnovpokaz[0].srednegodovayaviruchka;
            //variable1 = osnovpokaz[1].srednegodovayaviruchka;

            //dinamcreditzad.parse(null, out list<dinamcreditzad> dinamcreditzad);

            //iexcelserializer serializer = new excelserializerservice();
            //var a = serializer.convertexceltojson("c:\\users\\37529\\desktop\\1.xlsx", "основные показатели");
            //var aa = serializer.convertexceltojson("c:\\users\\37529\\desktop\\1.xlsx", "динамика кредит. задолж");
            //iparsingservice parser1 = new mainindicatesparsingservice();
            //iparsingservice parser1 = new kreditzad();
            //var b = parser1.parse(a, out idictionary<string, exceldata> indicates);
            //var tt = indicates.trygetvalue("productionvolume", out exceldata exceldata);
            //var ttt = exceldata as mainindicator;
        }
        private bool CanSwitchReceivingModeExecute(object p) => true;
        #endregion


       
        public MainWindowViewModel()
        {
            SwitchReceivingModeCommand = new LambdaCommand(OnSwitchReceivingModeExecuted, CanSwitchReceivingModeExecute);
            OpenFileCommand = new LambdaCommand(OnOpenFileExecuted, CanOpenFileExecute);
        }




    }

}
