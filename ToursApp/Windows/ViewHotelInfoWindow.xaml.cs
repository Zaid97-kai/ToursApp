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

namespace ToursApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для ViewHotelInfoWindow.xaml
    /// </summary>
    public partial class ViewHotelInfoWindow : Window
    {
        ToursDB_08Entities _context = new ToursDB_08Entities();
        List<HotelImage> hotelImages;
        Hotel _hotel;
        int _currentPage = 1;
        int _maxImages = 0;
        public ViewHotelInfoWindow(Hotel hotel)
        {
            InitializeComponent();

            _hotel = hotel;
            DataContext = hotel.HotelImages;

            _maxImages = hotel.HotelImages.ToList().Count;
            this.hotelImages = hotel.HotelImages.ToList();
            //MessageBox.Show(this.hotelImages.Count.ToString());
        }

        private void PrevImg_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            this.hotelImages = this.hotelImages.Skip(_currentPage - 1).Take(1).ToList();
            DataContext = this.hotelImages;

            this.hotelImages = _hotel.HotelImages.ToList();
        }

        private void NextImg_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            this.hotelImages = this.hotelImages.Skip(_currentPage - 1).Take(1).ToList();
            DataContext = this.hotelImages;

            this.hotelImages = _hotel.HotelImages.ToList();
        }
    }
}
