﻿using Prism.Services.Dialogs;
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
        /// <summary>
        /// Конструктор класса окна изменения/удаления информации об отеле
        /// </summary>
        /// <param name="o">Объект нажатой кнопки для обращения к привязанному отелю</param>
        /// <param name="toursDB_08Entities">Контекст данных</param>
        /// <param name="hotelsWindow">Окно со списком отелей</param>
        public EditHotelInfoWindow(object o, ToursDB_08Entities toursDB_08Entities, HotelsWindow hotelsWindow)
        {
            InitializeComponent();

            _context = toursDB_08Entities;
            _hotelsWindow = hotelsWindow;

            CmbNameCountry.ItemsSource = _context.Countries.ToList();
            _hotel = (o as Button).DataContext as Hotel;

            InsertHotelInfo();
            //DataContext = _hotel;
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
            //_context.SaveChanges();
            //_hotelsWindow.DataGridHotels.ItemsSource = _context.Hotels.OrderBy(h => h.Name).ToList();
            Hide();
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
    }
}
