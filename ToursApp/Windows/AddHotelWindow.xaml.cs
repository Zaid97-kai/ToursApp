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
    /// Логика взаимодействия для AddHotelWindow.xaml
    /// </summary>
    public partial class AddHotelWindow : Window
    {
        private ToursDB_08Entities _context = new ToursDB_08Entities();
        private string _selectedCountryCode = "";
        private Country _selectedCountry = null;

        private HotelsWindow _hotelsWindow;
        public AddHotelWindow(HotelsWindow hotelsWindow)
        {
            InitializeComponent();
            CmbNameCountry.ItemsSource = _context.Countries.ToList();
            _hotelsWindow = hotelsWindow;
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCountStars.Text != "" && TxtDescHotel.Text != "" && TxtNameHotel.Text != "" && CmbNameCountry.SelectedItem != null)
            {
                foreach (Country i in _context.Countries)
                {
                    if ((CmbNameCountry.SelectedItem as Country).Name == i.Name)
                    {
                        _selectedCountryCode = i.Name;
                        _selectedCountry = i;
                    }
                }

                if (Convert.ToInt32(TxtCountStars.Text) >= 0 && Convert.ToInt32(TxtCountStars.Text) <= 5)
                {
                    _context.Hotels.Add(new Hotel() { CountOfStars = Convert.ToInt32(TxtCountStars.Text), Name = TxtNameHotel.Text, CountryCode = _selectedCountryCode, Country = _selectedCountry, Description = TxtDescHotel.Text });
                    _context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Введено некорректное число (должно быть от 0 до 5!)");
                    return;
                }

                _hotelsWindow.DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
                _hotelsWindow.RefreshHotels();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Не все поля формы заполнены!");
            }
        }
    }
}
