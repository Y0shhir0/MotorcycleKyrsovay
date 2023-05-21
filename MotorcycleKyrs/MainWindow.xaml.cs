using MotorcycleKyrs.Entities;
using MotorcycleKyrs.Pages;
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

namespace MotorcycleKyrs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageCompany();
        }

        private void BtnСompany_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageCompany();
        }

        private void BtnProduction_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageMotorcycle();
        }

        private void BtnСustomerbase_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageKlient();
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageOrder();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
