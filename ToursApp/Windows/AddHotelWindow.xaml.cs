using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private string _selectedCountryCode;
        private Country _selectedCountry;
        private byte[] imageHotel;

        private HotelsWindow _hotelsWindow;
        public AddHotelWindow(HotelsWindow hotelsWindow)
        {
            InitializeComponent();
            CmbNameCountry.ItemsSource = _context.Countries.ToList();
            _hotelsWindow = hotelsWindow;
        }
        /// <summary>
        /// Кнопка добавления отеля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCountStars.Text != "" && TxtDescHotel.Text != "" && TxtNameHotel.Text != "" && CmbNameCountry.SelectedItem != null)
            {
                //Поиск страны из раскрывающегося списка
                foreach (Country i in _context.Countries)
                {
                    if ((CmbNameCountry.SelectedItem as Country).Name == i.Name)
                    {
                        _selectedCountryCode = i.Name;
                        _selectedCountry = i;
                    }
                }
                //Добавление отеля
                if (Convert.ToInt32(TxtCountStars.Text) >= 0 && Convert.ToInt32(TxtCountStars.Text) <= 5) //Проверка количества звезд
                {
                    Hotel hotel = new Hotel() { CountOfStars = Convert.ToInt32(TxtCountStars.Text), Name = TxtNameHotel.Text, CountryCode = _selectedCountryCode, Country = _selectedCountry, Description = TxtDescHotel.Text };
                    if (this.imageHotel != null)
                    {
                        hotel.HotelImages.Add(new HotelImage() { ImageSource = this.imageHotel, Hotel = hotel, HotelId = hotel.Id });
                    }
                    _context.Hotels.Add(hotel);

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

        private void Overview_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path;
            if(openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                this.imageHotel = System.IO.File.ReadAllBytes(path);

                //BitmapSource bitmapSource = BitmapSource.Create(255, 255, 300, 300, PixelFormats.Indexed8, BitmapPalettes.Gray256, this.imageHotel, 2);

                ImgHotel.Source = new BitmapImage(new Uri(path));
            }
        }
    }
}
