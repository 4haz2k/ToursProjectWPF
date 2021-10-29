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

namespace WPFToursProject
{
    /// <summary>
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        List<Tours> tours;
        public ToursPage()
        {
            
            InitializeComponent();
            tours = new List<Tours>
            {
                new Tours {
                    Name = "Геленджик",
                    IsActive = true,
                    Price = 1000,
                    TicketCount = 10
                },
                new Tours
                {
                    Name = "Москва",
                    IsActive = false,
                    Price = 300,
                    TicketCount = 1
                },
                new Tours
                {
                    Name = "Казань",
                    IsActive = true,
                    Price = 200,
                    TicketCount = 4
                },
                new Tours
                {
                    Name = "Санкт-Петербург",
                    IsActive = false,
                    Price = 100,
                    TicketCount = 2
                }
            };
            LViewTours.ItemsSource = tours;
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelsPage());
        }
    }
}
