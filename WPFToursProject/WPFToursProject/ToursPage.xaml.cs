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
        public ToursPage()
        {    
            InitializeComponent();
            FirstInit();
        }

        private void FirstInit()
        {
            var allTypes = TravelAgencyEntities1.GetEntities().Type.ToList();
            allTypes.Insert(0, new Type { Name = "Все типы" });
            ComboType.ItemsSource = allTypes;
            CheckActual.IsChecked = true;
            RadioButtonASC.IsChecked = true;
            GetFilteredTours();
        }

        private void GetFilteredTours()
        {
            var allTours = TravelAgencyEntities1.GetEntities().Tour.ToList();

            if (ComboType.SelectedIndex > 0)
                allTours = allTours.Where(p => p.Type.Contains(ComboType.SelectedItem as Type)).ToList();

            if(CheckActual.IsChecked.Value)
                allTours = allTours.Where(p => p.isActual).ToList();      

            allTours = allTours.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            decimal price = 0;
            foreach (var currentTour in allTours)
            {
                price += currentTour.Price * Convert.ToDecimal(currentTour.TicketCount);
            }

            TotalPrice.Text = $"Общая стоимость туров: {price} РУБ.";

            if (RadioButtonASC.IsChecked.Value)
                LViewTours.ItemsSource = allTours.OrderBy(p => p.Price).ToList();
            else
                LViewTours.ItemsSource = allTours.OrderByDescending(p => p.Price).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetFilteredTours();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetFilteredTours();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            GetFilteredTours();
        }


        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelsPage());
        }

        private void CheckActual_Checked_ASC(object sender, RoutedEventArgs e)
        {
            GetFilteredTours();
        }

        private void CheckActual_Checked_DESC(object sender, RoutedEventArgs e)
        {
            GetFilteredTours();
        }
    }
}
