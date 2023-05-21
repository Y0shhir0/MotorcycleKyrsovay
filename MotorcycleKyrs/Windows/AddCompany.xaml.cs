using MotorcycleKyrs.Entities;
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

namespace MotorcycleKyrs.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Window
    {
        private Company _currentcompany = new Company();
        public AddCompany(Company company)
        {
            InitializeComponent();
            if (company != null)
                _currentcompany = company;
            DataContext = _currentcompany;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                { 
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentcompany.C_ID == 0)
                    Motor.GetContext().Companies.Add(_currentcompany);
                Motor.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private StringBuilder CheckField()
        {
            StringBuilder str = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentcompany.C_Title))
                str.AppendLine("Поле Название введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentcompany.C_Address))
                str.AppendLine("Поле Адрес введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentcompany.C_Phone))
                str.AppendLine("Поле Телефон введено некорректно");
            return str;
        }


    }
}
