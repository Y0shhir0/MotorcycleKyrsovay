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
    /// Логика взаимодействия для PageKlient.xaml
    /// </summary>
    public partial class PageKlient : Page
    {
        public PageKlient()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridKlient.SelectedItem is Klient klient)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        Motor.GetContext().Klients.Remove(klient);
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
            if (DataGridKlient.SelectedItem is Klient klient)
            {
                AddKlient addKlient = new AddKlient(klient);
                addKlient.Show();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddKlient addKlient = new AddKlient(null);
            addKlient.Show();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridKlient.ItemsSource = Motor.GetContext().Klients.ToList();
        }
    }
}
