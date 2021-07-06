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
            ListTours.ItemsSource = _context.Tours.ToList();
            CmbTypes.ItemsSource = _context.Types.OrderBy(types => types.Name).ToList();

            this._tours = _context.Tours.ToList();
        }

        public void RefreshTours()
        {
            _tours = (from t in _tours
                     from tn in t.Types
                     where tn.Name == _SelectedType
                     select t).ToList();

            ListTours.ItemsSource = _tours;
        }

        private void TxtFindedTourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._FindedName = TxtFindedTourName.Text;
        }

        private void CmbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._tours = _context.Tours.ToList();

            Type type = CmbTypes.SelectedItem as Type;
            this._SelectedType = type.Name;
            RefreshTours();
        }
    }
}
