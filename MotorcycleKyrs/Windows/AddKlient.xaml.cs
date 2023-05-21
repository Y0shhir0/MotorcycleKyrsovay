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
    /// Логика взаимодействия для AddKlient.xaml
    /// </summary>
    public partial class AddKlient : Window
    {
        private Klient _currentklient = new Klient();
        public AddKlient(Klient klient)
        {
            InitializeComponent();
            if (klient != null)
                _currentklient = klient;
            DataContext = _currentklient;
            Address.ItemsSource = Motor.GetContext().Klients.ToList();
            Phone.ItemsSource = Motor.GetContext().Klients.ToList();
        }

   
        private StringBuilder CheckField()
        {
            StringBuilder str = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentklient.K_Name))
                str.AppendLine("Поле  Имя введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentklient.K_Surname))
                str.AppendLine("Поле Фамилия введена некорректно");
            if (Address.SelectedItem == null)
                str.AppendLine("Выберите адрес");
            if (Phone.SelectedItem == null)
                str.AppendLine("Выберите телефон");
            return str;
        }

        private void BtnOk_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentklient.K_ID == 0)
                    Motor.GetContext().Klients.Add(_currentklient);
                Motor.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
