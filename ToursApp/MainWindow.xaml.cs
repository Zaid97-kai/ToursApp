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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToursDB_08Entities _context = new ToursDB_08Entities();
        private List<Tour> _tours = new List<Tour>();
        private string _SelectedType = "";
        private string _FindedName = "";
        public MainWindow()
        {
            InitializeComponent();
            ListTours.ItemsSource = _context.Tours.OrderBy(tour => tour.Name).ToList();
            CmbTypes.ItemsSource = _context.Types.OrderBy(types => types.Name).ToList();

            this._tours = _context.Tours.ToList();
        }

        public void RefreshTours()
        {
            if (CmbTypes.SelectedItem != null)
            {
                _tours = (from t in _tours
                          from tn in t.Types
                            where tn.Name == _SelectedType
                          select t).ToList();
            }

            if (TxtFindedTourName.Text != "")
            {
                _tours = _tours.OrderBy(tour => tour.Name).Where(tour => tour.Name == _FindedName).ToList();
            }

            if ((bool)ChbActual.IsChecked)
            {
                _tours = _tours.OrderBy(tour => tour.Name).Where(tour => tour.IsActual).ToList();
            }
            //else if(!(bool)ChbActual.IsChecked)
            //{
            //    _tours = _tours.OrderBy(tour => tour.Name).Where(tour => tour.IsActual == false).ToList();
            //}

            ListTours.ItemsSource = _tours;
        }

        private void TxtFindedTourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._tours = _context.Tours.OrderBy(tour => tour.Name).ToList();

            this._FindedName = TxtFindedTourName.Text;
            RefreshTours();
        }

        private void CmbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tours = _context.Tours.ToList();

            Type type = CmbTypes.SelectedItem as Type;
            _SelectedType = type.Name;
            RefreshTours();
        }

        private void ChbActual_Checked(object sender, RoutedEventArgs e)
        {
            CheckedStatusController();
        }

        private void CheckedStatusController()
        {
            this._tours = _context.Tours.OrderBy(tour => tour.Name).ToList();
            RefreshTours();
        }

        private void ChbActual_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckedStatusController();
        }

        private void BtnListHotelsView_Click(object sender, RoutedEventArgs e)
        {
            HotelsWindow hotelsWindow = new HotelsWindow();

            //hotelsWindow.Owner = this;
            hotelsWindow.Show();
        }
    }
}
