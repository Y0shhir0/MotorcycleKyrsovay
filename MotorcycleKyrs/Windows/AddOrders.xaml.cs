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
    /// Логика взаимодействия для AddOrders.xaml
    /// </summary>
    public partial class AddOrders : Window
    {
        private Order _currentorder = new Order();
        private int quantity = 1;
        public AddOrders( Order order)
        {
            InitializeComponent();
            if (order != null)
                _currentorder = order;
            DataContext = _currentorder;
            O_Order_date.ItemsSource = Motor.GetContext().Orders.ToList();
            O_Price.ItemsSource = Motor.GetContext().Orders.ToList();
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
                if (_currentorder.O_ID == 0)
                    Motor.GetContext().Orders.Add(_currentorder);
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
            if (!int.TryParse(Btt.Text, out quantity))
                str.AppendLine("Поле Ид-мотоцикла только число");
            if (!int.TryParse(Btr.Text, out quantity))
                str.AppendLine("Поле Ид-клиента  только число");
            if (O_Order_date.SelectedItem == null)
                str.AppendLine("Выберите дату");
            if (O_Price.SelectedItem == null)
                str.AppendLine("Выберите цену");
            return str;
        }
    }
}
