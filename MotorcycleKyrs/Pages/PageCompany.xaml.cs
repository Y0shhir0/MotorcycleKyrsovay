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
    /// Логика взаимодействия для PageCompany.xaml
    /// </summary>
    public partial class PageCompany : Page
    {
        public PageCompany()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCompany addCompany = new AddCompany(null);
            addCompany.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCompany.SelectedItem is Company company)
            {
                AddCompany addCompany = new AddCompany(company);
                addCompany.Show();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCompany.SelectedItem is Company company)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        Motor.GetContext().Companies.Remove(company);
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

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridCompany.ItemsSource = Motor.GetContext().Companies.ToList();
        }
    }
}
