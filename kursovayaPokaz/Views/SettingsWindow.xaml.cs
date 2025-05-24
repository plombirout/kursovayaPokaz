using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursovayaPokaz
{
    public partial class SettingsWindow : Window
    {
        public OrganizationSettings Settings { get; private set; }

        public SettingsWindow()
        {
            InitializeComponent();
            Settings = new OrganizationSettings();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(OrgNameInput.Text) ||
                string.IsNullOrWhiteSpace(UNPInput.Text))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля (помечены *)");
                return;
            }

            Settings.OrganizationName = OrgNameInput.Text;
            Settings.UNP = UNPInput.Text;
            Settings.ActivityType = ActivityInput.Text;
            Settings.LegalAddress = AddressInput.Text;
            Settings.Director = DirectorInput.Text;
            Settings.ChiefAccountant = AccountantInput.Text;
            Settings.ResponsibleExecutor = ExecutorInput.Text;

            DialogResult = true;
            Close();
        }
    }

    public class OrganizationSettings
    {
        public string OrganizationName { get; set; }
        public string UNP { get; set; }
        public string ActivityType { get; set; }
        public string LegalAddress { get; set; }
        public string Director { get; set; }
        public string ChiefAccountant { get; set; }
        public string ResponsibleExecutor { get; set; }
    }
}