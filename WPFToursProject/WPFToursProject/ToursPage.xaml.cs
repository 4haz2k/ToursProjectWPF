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

        /// <summary>
        /// Первая инициализация страницы
        /// </summary>
        private void FirstInit()
        {
            //получение всех туров
            var allTypes = TravelAgencyEntities1.GetEntities().Type.ToList();

            //установка первого инедекса для кореектного отображения в combobox
            allTypes.Insert(0, new Type { Name = "Все типы" });
            
            //передача данных
            ComboType.ItemsSource = allTypes;

            //задание первых параметров
            CheckActual.IsChecked = true;
            RadioButtonASC.IsChecked = true;
            GetFilteredTours();
        }

        /// <summary>
        /// Получение туров с учетом фильтров
        /// </summary>
        private void GetFilteredTours()
        {
            //получение всех туров
            var allTours = TravelAgencyEntities1.GetEntities().Tour.ToList();

            //сортировка по типу
            if (ComboType.SelectedIndex > 0)
                allTours = allTours.Where(p => p.Type.Contains(ComboType.SelectedItem as Type)).ToList();

            //сортировка по актуальным турам
            if(CheckActual.IsChecked.Value)
                allTours = allTours.Where(p => p.isActual).ToList();      

            //сортировка по введенным данным в поле "Название тура"
            allTours = allTours.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            //подсчет общей стоимости туров
            decimal price = 0;
            foreach (var currentTour in allTours)
            {
                price += currentTour.Price * Convert.ToDecimal(currentTour.TicketCount);
            }

            TotalPrice.Text = $"Общая стоимость туров: {price} РУБ.";

            //сортировка по убыванию / возрастанию
            if (RadioButtonASC.IsChecked.Value)
                LViewTours.ItemsSource = allTours.OrderBy(p => p.Price).ToList();
            else
                LViewTours.ItemsSource = allTours.OrderByDescending(p => p.Price).ToList();
        }

        /// <summary>
        /// Срабатывание события при пользовательском вводе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetFilteredTours();
        }

        /// <summary>
        /// Срабатывание выбора типа тура
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetFilteredTours();
        }

        /// <summary>
        /// Срабатывание кнопки "Только актуальные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            GetFilteredTours();
        }

        /// <summary>
        /// Срабатывание кнопки "Отели"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HotelsPage());
        }

        /// <summary>
        /// Срабатывание кнопки "По возрастанию"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckActual_Checked_ASC(object sender, RoutedEventArgs e)
        {
            GetFilteredTours();
        }

        /// <summary>
        /// Срабатывание кнопки "По убыванию"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckActual_Checked_DESC(object sender, RoutedEventArgs e)
        {
            GetFilteredTours();
        }
    }
}
