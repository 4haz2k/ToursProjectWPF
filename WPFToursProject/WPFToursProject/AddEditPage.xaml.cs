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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel currentHotel = new Hotel();

        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                currentHotel = selectedHotel;

            DataContext = currentHotel;
            ComboCountries.ItemsSource = TravelAgencyEntities1.GetEntities().Country.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentHotel.Name))
                errors.AppendLine("Необходимо указать название отеля");
            if (currentHotel.Country == null)
                errors.AppendLine("Необходимо выбрать страну");
            if (currentHotel.CountOfStars < 1 || currentHotel.CountOfStars > 5)
                errors.AppendLine("Кол-во звёзд может быть только от 1 до 5");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentHotel.id == 0)
                TravelAgencyEntities1.GetEntities().Hotel.Add(currentHotel);

            try
            {
                TravelAgencyEntities1.GetEntities().SaveChanges();
                MessageBox.Show("Отель сохранен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
