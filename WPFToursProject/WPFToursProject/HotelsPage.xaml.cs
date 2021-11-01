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
        public HotelsPage()
        {
            InitializeComponent();
            PaginationInit();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotel = (sender as Button).DataContext as Hotel;

            if(MessageBox.Show($"Вы точно хотите удалить отель {hotel.Name}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try {
                    TravelAgencyEntities1.GetEntities().Hotel.Remove(hotel);
                    TravelAgencyEntities1.GetEntities().SaveChanges();
                    MessageBox.Show("Отель удален.");

                    PaginationInit();
                    DGridHotels.ItemsSource = TravelAgencyEntities1.GetEntities().Hotel.ToList().Take(Paginator.NeedToView);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                TravelAgencyEntities1.GetEntities().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                PaginationInit();
                DGridHotels.ItemsSource = TravelAgencyEntities1.GetEntities().Hotel.ToList().Take(Paginator.NeedToView);
            }
        }

        private void PaginationInit()
        {
            List<PagesComboBox> ListOfRange = new List<PagesComboBox>();
            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList();
            Paginator.DataCount = hotels.Count();
            PagesCount.Text = $"1 / {Paginator.TotalPages}";

            for(int i = 1; i <= Paginator.TotalPages; i++)
            {
                ListOfRange.Add(new PagesComboBox()
                {
                    index = i,
                    Value = i * 10
                });
            }

            Paginator.NeedToView = 10;
            Paginator.CurrentPage = 1;
            PaginationComboBox.ItemsSource = ListOfRange;
            PaginationComboBox.SelectedIndex = 0;
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            Paginator.CurrentPage = 1;

            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            Paginator.CurrentPage = Paginator.TotalPages;

            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.TotalPages - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        private void PaginationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Paginator.NeedToView = (PaginationComboBox.SelectedIndex + 1) * 10;

            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.CurrentPage - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (Paginator.CurrentPage == Paginator.TotalPages)
                return;

            Paginator.CurrentPage += 1;

            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.CurrentPage - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (Paginator.CurrentPage == 1)
                return;
            else
                Paginator.CurrentPage -= 1;

            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.CurrentPage - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }
    }
}
