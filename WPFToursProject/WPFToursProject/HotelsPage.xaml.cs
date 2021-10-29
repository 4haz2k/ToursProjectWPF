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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        List<Hotels> hotels;
        public HotelsPage()
        {
            InitializeComponent();
            hotels = new List<Hotels> {
                new Hotels
                {
                    Name = "ГрантОтель",
                    CountOfStars = 5,
                    Country = "Россия"
                },
                new Hotels
                {
                    Name = "МоскваОтель",
                    CountOfStars = 3,
                    Country = "Россия"
                },
                new Hotels
                {
                    Name = "КазаньОтель",
                    CountOfStars = 5,
                    Country = "Россия"
                },
            };
            DGridHotels.ItemsSource = hotels;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
