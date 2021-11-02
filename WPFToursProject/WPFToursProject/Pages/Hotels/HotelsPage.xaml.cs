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

            // первая инициализация пагинации
            PaginationInit();
        }

        /// <summary>
        /// Нажатие кнопки "Редактировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel));
        }

        /// <summary>
        /// Нажатие кнопки "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        /// <summary>
        /// Нажатие кнопки "Х"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotel = (sender as Button).DataContext as Hotel;

            //запрос пользователю на удаление отеля
            if(MessageBox.Show($"Вы точно хотите удалить отель {hotel.Name}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //переход на страницу подтверждения
                Manager.MainFrame.Navigate(new Verification((sender as Button).DataContext as Hotel));
            }
        }

        /// <summary>
        /// Событие смены отображения страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // обновление страницы при смене видимости страницы
            if(Visibility == Visibility.Visible)
            {
                TravelAgencyEntities1.GetEntities().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                PaginationInit();
                DGridHotels.ItemsSource = TravelAgencyEntities1.GetEntities().Hotel.ToList().Take(Paginator.NeedToView);
            }
        }

        /// <summary>
        /// Обновление пагинации при инициализации страницы или обновления контента
        /// </summary>
        private void PaginationInit()
        {
            //создание списка для ComboBox с получением данных
            List<PagesComboBox> ListOfRange = new List<PagesComboBox>();
            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList();

            //хренение данных о пагинации
            Paginator.DataCount = hotels.Count();
            PagesCount.Text = $"1 / {Paginator.TotalPages}";

            //добавление данных в ListOfRange
            for (int i = 1; i <= Paginator.TotalPages; i++)
            {
                ListOfRange.Add(new PagesComboBox()
                {
                    Index = i,
                    Value = i * 10
                });
            }

            //задание параметров для пагинации
            Paginator.NeedToView = 10;
            Paginator.CurrentPage = 1;

            //добавление данных в PaginationComboBox
            PaginationComboBox.ItemsSource = ListOfRange;
            PaginationComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Нажатие кнопки "Первая страница"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            // смена текущей страницы на первую
            Paginator.CurrentPage = 1;

            // смена отображения кол-ва страниц
            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            // получения данных из бд с новыми параметрами
            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        /// <summary>
        /// Нажатие кнопки "Последняя страница"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            // смена текущей страницы
            Paginator.CurrentPage = Paginator.TotalPages;

            // смена отображения кол-ва страниц
            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            // получения данных из бд с новыми параметрами
            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.TotalPages - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        /// <summary>
        /// Выбор поля строк отображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaginationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // смена отображения кол-ва строк
            Paginator.NeedToView = (PaginationComboBox.SelectedIndex + 1) * 10;

            // смена отображения кол-ва страниц
            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            // получения нового кол-ва строк из бд
            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.CurrentPage - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        /// <summary>
        /// Нажатие кнопки "Следующая страница"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (Paginator.CurrentPage == Paginator.TotalPages)
                return;

            Paginator.CurrentPage += 1;

            PagesCount.Text = $"{Paginator.CurrentPage} / {Paginator.TotalPages}";

            var hotels = TravelAgencyEntities1.GetEntities().Hotel.ToList().Skip((Paginator.CurrentPage - 1) * 10).Take(Paginator.NeedToView);

            DGridHotels.ItemsSource = hotels;
        }

        /// <summary>
        /// Нажатие кнопки "Предыдущая страница"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
