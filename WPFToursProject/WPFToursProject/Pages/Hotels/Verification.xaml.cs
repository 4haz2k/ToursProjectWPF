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
        private Hotel currentHotel = new Hotel();

        public Verification(Hotel selectedHotel)
        {
            InitializeComponent();
            currentHotel = selectedHotel;
        }

        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(VerifyTextBox.Text))
            {
                if (currentHotel.Name.Equals(VerifyTextBox.Text))
                {
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
