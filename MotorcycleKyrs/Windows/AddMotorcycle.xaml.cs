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
    /// Логика взаимодействия для AddMotorcycle.xaml
    /// </summary>
    public partial class AddMotorcycle : Window
    {

        private int quantity = 0;
        private Motorcycle _currentmotorcycle = new Motorcycle();
        public AddMotorcycle(Motorcycle motorcycle)
        {
            InitializeComponent();
            if (motorcycle != null)
                _currentmotorcycle = motorcycle;
            DataContext = _currentmotorcycle;
            Models.ItemsSource = Motor.GetContext().Motorcycles.ToList();
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
                if (_currentmotorcycle.M_ID == 0)
                    Motor.GetContext().Motorcycles.Add(_currentmotorcycle);
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
            if (!int.TryParse(Bty.Text, out quantity))
                str.AppendLine("Поле Ид-компании только число");
            else if (quantity < 0)
                str.AppendLine("Поле не может быть отрицательным");
            if (Models.SelectedItem == null)
                str.AppendLine("Выберите Модель");
            if (!int.TryParse(Btt.Text, out quantity)) 
                str.AppendLine("Поле год выпуска только число");
            else if (quantity < 0)
                str.AppendLine("Поле не может быть отрицательным");
            if (!int.TryParse(Btn.Text, out quantity))
                str.AppendLine("Поле Объем двигателя только число");
            else if (quantity < 0)
                str.AppendLine("Поле не может быть отрицательным");
            if (!int.TryParse(Btr.Text, out quantity))
                str.AppendLine("Поле Макс-скорости только число");
            else if (quantity < 0)
                str.AppendLine("Поле не может быть отрицательным");
            return str;
        }
    }
}
