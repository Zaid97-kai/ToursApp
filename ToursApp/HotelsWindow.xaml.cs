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
using System.Windows.Shapes;
using ToursApp.Windows;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для HotelsWindow.xaml
    /// </summary>
    public partial class HotelsWindow : Window
    {
        private ToursDB_08Entities _context = new ToursDB_08Entities();
        private int _currentPage = 1;
        private int _maxPage = 0;
        public HotelsWindow()
        {
            InitializeComponent();

            RefreshHotels(); 
        }

        /// <summary>
        /// Обновление списка отелей при загрузке и пагинации
        /// </summary>
        /// <returns></returns>
        private bool RefreshHotels()
        {
            try
            {
                DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
                _maxPage = Convert.ToInt32(Math.Ceiling(_context.Hotels.ToList().Count * 1.0 / 10));
                var listHotels = _context.Hotels.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

                LblTotalPages.Content = "of " + _maxPage.ToString();
                TxtCurrentPageNumber.Text = _currentPage.ToString();

                DataGridHotels.ItemsSource = listHotels;

                TxtCountRecords.Text = "Количество записей: " + _context.Hotels.ToList().Count.ToString() + " ";
                TxtCountRecordsInCurrentPage.Text = "Количество записей в текущей странице: " + listHotels.Count.ToString() + " ";

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void BtnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            EditHotelInfoWindow editHotelInfoWindow = new EditHotelInfoWindow(sender, _context, this);
            editHotelInfoWindow.Show();
        }

        private void GoLastPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshHotels();
        }

        private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage + 1 > _maxPage)
            {
                return;
            }
            _currentPage++;
            RefreshHotels();
        }

        private void GoPrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage - 1 < 1)
            { 
                return;
            }
            _currentPage--;
            RefreshHotels();
        }

        private void GoFirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshHotels();
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            AddHotelWindow addHotelWindow = new AddHotelWindow(this);
            addHotelWindow.Show();
        }

        private void TxtCurrentPageNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_currentPage > 0 && _currentPage < _maxPage)
            {
                _currentPage = Convert.ToInt32(TxtCurrentPageNumber.Text);
                RefreshHotels();
            }
        }
    }
}
