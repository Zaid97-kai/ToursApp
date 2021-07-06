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
        public HotelsWindow()
        {
            InitializeComponent();

            DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
        }

        private void BtnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            EditHotelInfoWindow editHotelInfoWindow = new EditHotelInfoWindow(sender, _context, this);
            editHotelInfoWindow.Show();
        }
    }
}
