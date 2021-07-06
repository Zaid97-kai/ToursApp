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
    /// Логика взаимодействия для ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        private ToursDB_08Entities _context;
        private EditHotelInfoWindow _editHotelInfoWindow;
        private Hotel _hotel;
        private HotelsWindow _hotelsWindow;
        public ConfirmWindow(ToursDB_08Entities toursDB_08Entities, Hotel hotel, HotelsWindow hotelsWindow, EditHotelInfoWindow editHotelInfoWindow)
        {
            InitializeComponent();
            _context = toursDB_08Entities;
            _hotel = hotel;
            _hotelsWindow = hotelsWindow;
            _editHotelInfoWindow = editHotelInfoWindow;

            TxtConfirmMsg.Text = "Вы уверены, что хотите удалить отель " + _hotel.Name + "?";
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _context.Hotels.Remove(_hotel);
            _context.SaveChanges();

            _hotelsWindow.DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
            _hotelsWindow.RefreshHotels();
            _editHotelInfoWindow.Hide();
            this.Hide();
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление отклонено.");
            Hide();
        }
    }
}
