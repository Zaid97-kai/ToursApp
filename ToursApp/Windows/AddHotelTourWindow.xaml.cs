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
    /// Логика взаимодействия для AddHotelTourWindow.xaml
    /// </summary>
    public partial class AddHotelTourWindow : Window
    {
        private ToursDB_08Entities _context = new ToursDB_08Entities();
        public AddHotelTourWindow()
        {
            InitializeComponent();

            CmbListHotels.ItemsSource = _context.Hotels.ToList();
            CmbListTours.ItemsSource = _context.Tours.ToList();
        }

        private void BtnAddHotelTour_Click(object sender, RoutedEventArgs e)
        {
            Tour tour = CmbListTours.SelectedItem as Tour;
            Hotel hotel = CmbListHotels.SelectedItem as Hotel;
            hotel.Tours.Add(tour);
            tour.Hotels.Add(hotel);
            _context.SaveChanges();
            this.Close();
        }
    }
}
