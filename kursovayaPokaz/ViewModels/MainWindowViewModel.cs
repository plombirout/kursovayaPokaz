using kursovayaPokaz.Commands;
using kursovayaPokaz.Models;
using kursovayaPokaz.Services.ExcelSerializer;
using kursovayaPokaz.Services.ParsingServices;
using kursovayaPokaz.ViewModels.Base;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kursovayaPokaz.ViewModels
{
    class bufer {
        public ExcelData aa;
    } 
    class MainWindowViewModel : ViewModel
    {
        #region Title : string - Window title

        /// <summary>
        /// Window title
        /// </summary>

        private string _Title = "Выполнил: Зайцев Артем Денисович, студент группы ИСИТ-221";

        /// <summary>
        /// Window title
        /// </summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        private double _variable;
        public double variable { get => _variable; set => Set(ref _variable, value); }

        private double _variable1;
        public double variable1 { get => _variable1; set => Set(ref _variable1, value); }

        #endregion
        #region SwitchReceivingMode
        public ICommand SwitchReceivingModeCommand { get; }

        private void OnSwitchReceivingModeExecuted(object p)
        {
            //OsnovPokaz.Parse(null, out List<OsnovPokaz> osnovPokaz);
            //  variable = osnovPokaz[0].SrednegodovayaViruchka;
            //  variable1 = osnovPokaz[1].SrednegodovayaViruchka;

            // DinamCreditZad.Parse(null, out List<DinamCreditZad> dinamCreditZad);
            
            IExcelSerializer serializer = new ExcelSerializerService();
            var a = serializer.ConvertExcelToJson("C:\\Users\\37529\\Desktop\\1.xlsx", "динамика кредит. задолж");
            // IParsingService parser1 = new MainIndicatesParsingService();
            IParsingService parser1 = new KreditZad();
            var b = parser1.Parse(a, out IDictionary<string, ExcelData> indicates);
            var t = indicates.TryGetValue("Долгосрочная кредиторская задолженность", out ExcelData excelData);
            var tt = excelData as MainIndicator;


            

        }
        private bool CanSwitchReceivingModeExecute(object p) => true;
        #endregion
        public MainWindowViewModel()
        {
            SwitchReceivingModeCommand = new LambdaCommand(OnSwitchReceivingModeExecuted, CanSwitchReceivingModeExecute);
        }

    }

}
