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
    /// Логика взаимодействия для EditHotelInfoWindow.xaml
    /// </summary>
    public partial class EditHotelInfoWindow : Window
    {
        private ToursDB_08Entities _context;
        private Hotel _hotel = new Hotel();
        private HotelsWindow _hotelsWindow;
        public EditHotelInfoWindow(object o, ToursDB_08Entities toursDB_08Entities, HotelsWindow hotelsWindow)
        {
            InitializeComponent();

            _context = toursDB_08Entities;
            _hotelsWindow = hotelsWindow;

            CmbNameCountry.ItemsSource = _context.Countries.ToList();
            _hotel = (o as Button).DataContext as Hotel;

            TxtNameHotel.Text = _hotel.Name;
            TxtCountStars.Text = Convert.ToString(_hotel.CountOfStars);
            CmbNameCountry.SelectedItem = _hotel.Country;
        }

        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUpadateHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            _hotel.Name = TxtNameHotel.Text;
            _hotel.CountOfStars = Convert.ToInt32(TxtCountStars.Text);
            _hotel.Country = CmbNameCountry.SelectedItem as Country;
            _context.SaveChanges();

            _hotelsWindow.DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
            Hide();
        }
    }
}
