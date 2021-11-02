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
        /// <summary>
        /// Данные о переданном отеле
        /// </summary>
        private Hotel currentHotel = new Hotel();

        /// <summary>
        /// Конструктор страницы верификации 
        /// </summary>
        /// <param name="selectedHotel">Отель для редактирования</param>
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            //если отель нужно редактировать, то присваиваем значение
            if (selectedHotel != null)
                currentHotel = selectedHotel;

            DataContext = currentHotel;
            ComboCountries.ItemsSource = TravelAgencyEntities1.GetEntities().Country.ToList();
        }
        
        /// <summary>
        /// Кнопка "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            //Необходимо указать название отеля
            if (string.IsNullOrWhiteSpace(currentHotel.Name))
                errors.AppendLine("Необходимо указать название отеля");

            //Необходимо выбрать страну
            if (currentHotel.Country == null)
                errors.AppendLine("Необходимо выбрать страну");

            //Кол-во звёзд может быть только от 1 до 5
            if (currentHotel.CountOfStars < 1 || currentHotel.CountOfStars > 5)
                errors.AppendLine("Кол-во звёзд может быть только от 1 до 5");

            //если есть ошибки, то показываем и выходим
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //если отель джобавляем, то его индекс равен 0, проверяем это и добавляем если это так
            if (currentHotel.id == 0)
                TravelAgencyEntities1.GetEntities().Hotel.Add(currentHotel);

            //сохраняем изменения
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
