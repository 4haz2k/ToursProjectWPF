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
    /// Логика взаимодействия для Verification.xaml
    /// </summary>
    public partial class Verification : Page
    {
        /// <summary>
        /// Данные о переданном отеле
        /// </summary>
        private Hotel currentHotel = new Hotel();

        /// <summary>
        /// Конструктор страницы верификации 
        /// </summary>
        /// <param name="selectedHotel">Отель для удаления</param>
        public Verification(Hotel selectedHotel)
        {
            InitializeComponent();
            currentHotel = selectedHotel;
        }

        /// <summary>
        /// Срабатывание кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            //проверка на пустое поле
            if (!string.IsNullOrWhiteSpace(VerifyTextBox.Text))
            {
                //сравнение данных, а именно названия отеля и того, что ввёл пользователь
                if (currentHotel.Name.Equals(VerifyTextBox.Text))
                {
                    //удаление отеля
                    try
                    {
                        TravelAgencyEntities1.GetEntities().Hotel.Remove(currentHotel);
                        TravelAgencyEntities1.GetEntities().SaveChanges();

                        MessageBox.Show("Отель удален.");

                        Manager.MainFrame.Navigate(new HotelsPage());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Название отеля не совпадает со строкой подтверждения.");
                }
            }
            else
            {
                MessageBox.Show("Необходимо подтвердить удаление, введя название отеля.");
            }
        }
    }
}
