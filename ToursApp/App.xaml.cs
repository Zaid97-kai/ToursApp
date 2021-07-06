using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    public partial class Tour
    {
        public string ImgPath
        {
            get
            {
                return "/Resources/" + this.ImagePreview;
            }
        }
        public string State
        {
            get
            {
                if (IsActual)
                {
                    return "Актуален";
                }
                else
                {
                    return "Не актуален";
                }
            }
        }
        public SolidColorBrush solidColorBrush
        {
            get
            {
                if (IsActual)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.Red;
                }
            }
        }
        public string FullViewPrice
        {
            get
            {
                return (int)this.Price + " рублей";
            }
        }
        public string FullTicketCount
        {
            get
            {
                return "Количество билетов: " + this.TicketCount;
            }
        }
    }
    public partial class Hotel
    {
        /// <summary>
        /// Количество актуальных доступных туров
        /// </summary>
        public int NumberOfToursAvailable
        {
            get
            {
                return this.Tours.Where(x => x.IsActual).Count();
            }
        }
    }
}
