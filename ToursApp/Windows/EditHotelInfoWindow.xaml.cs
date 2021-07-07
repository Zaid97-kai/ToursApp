using Microsoft.Win32;
using Prism.Services.Dialogs;
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
        private ToursDB_08Entities _context; //контекст данных
        private Hotel _hotel;
        private HotelsWindow _hotelsWindow;
        private byte[] imageHotel;

        List<HotelImage> hotelImages;
        int _currentPage = 1;
        int _maxImages = 0;

        /// <summary>
        /// Конструктор класса окна изменения/удаления информации об отеле
        /// </summary>
        /// <param name="o">Объект нажатой кнопки для обращения к привязанному отелю</param>
        /// <param name="toursDB_08Entities">Контекст данных</param>
        /// <param name="hotelsWindow">Окно со списком отелей</param>
        public EditHotelInfoWindow(object o, ToursDB_08Entities toursDB_08Entities, HotelsWindow hotelsWindow)
        {
            InitializeComponent();
            _hotel = (o as Button).DataContext as Hotel;
            DataContext = _hotel.HotelImages;

            _maxImages = _hotel.HotelImages.ToList().Count;
            this.hotelImages = _hotel.HotelImages.ToList();

            _context = toursDB_08Entities;
            _hotelsWindow = hotelsWindow;

            CmbNameCountry.ItemsSource = _context.Countries.ToList();

            InsertHotelInfo();
        }

        private void InsertHotelInfo()
        {
            TxtNameHotel.Text = _hotel.Name;
            TxtCountStars.Text = Convert.ToString(_hotel.CountOfStars);
            CmbNameCountry.SelectedItem = _hotel.Country;
        }

        /// <summary>
        /// Удаление отеля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            ConfirmWindow confirmWindow = new ConfirmWindow(_context, _hotel, _hotelsWindow, this);
            confirmWindow.Show();

            //var result= MessageBox.Show(_hotel.Name, "Хотите удалить отель?", MessageBoxButton.YesNoCancel);
            //if (result==MessageBoxResult.Yes)
            //{

            //}
        }
        /// <summary>
        /// Изменение информации об отеле
        /// </summary>
        /// <param name="sender">Объект-кнопка, вызывающий событие</param>
        /// <param name="e"></param>
        private void BtnUpadateHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateHotelProperty();
            _hotelsWindow.RefreshHotels();
            _context.SaveChanges();

            //HotelsWindow._context.SaveChanges();
            //_hotelsWindow.RefreshHotels();
            //_hotelsWindow.DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
            //Hide();
            this.Close();
        }
        /// <summary>
        /// Обновление информации об отеле
        /// </summary>
        private void UpdateHotelProperty()
        {
            _hotel.Name = TxtNameHotel.Text;
            _hotel.CountOfStars = Convert.ToInt32(TxtCountStars.Text);
            _hotel.Country = CmbNameCountry.SelectedItem as Country;
        }

        private void Overview_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path;
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                this.imageHotel = System.IO.File.ReadAllBytes(path);

                //BitmapSource bitmapSource = BitmapSource.Create(255, 255, 300, 300, PixelFormats.Indexed8, BitmapPalettes.Gray256, this.imageHotel, 2);

                ImgHotel.Source = new BitmapImage(new Uri(path));
            }

            try
            {
                _hotel.HotelImages.Add(new HotelImage(){ Hotel = _hotel, HotelId = _hotel.Id, ImageSource = this.imageHotel });
                _context.SaveChanges();
                MessageBox.Show("Картинка успешно добавлена!");
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
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
