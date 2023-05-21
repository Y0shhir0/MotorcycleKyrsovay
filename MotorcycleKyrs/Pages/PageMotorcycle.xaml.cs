using MotorcycleKyrs.Entities;
using MotorcycleKyrs.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotorcycleKyrs.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMotorcycle.xaml
    /// </summary>
    public partial class PageMotorcycle : Page
    {
        public PageMotorcycle()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridMotorcycle.SelectedItem is Motorcycle motorcycle)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        Motor.GetContext().Motorcycles.Remove(motorcycle);
                        Motor.GetContext().SaveChanges();
                        Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
                        MessageBox.Show("Запись удалена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridMotorcycle.SelectedItem is Motorcycle motorcycle)
            {
                AddMotorcycle addMotorcycle = new AddMotorcycle(motorcycle);
                addMotorcycle.Show();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMotorcycle addMotorcycle = new AddMotorcycle(null);
            addMotorcycle.Show();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridMotorcycle.ItemsSource = Motor.GetContext().Motorcycles.ToList();
        }
    }
}
