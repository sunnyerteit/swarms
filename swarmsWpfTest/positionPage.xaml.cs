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

namespace swarmsWpfTest
{
    /// <summary>
    /// Interaction logic for positionPage.xaml
    /// </summary>
    public partial class positionPage : Page
    {
        public positionPage(double _longitude, double _latitude, double _depth, double _sog, string _heading)
        {
            InitializeComponent();
            _lLongitude.Content = _longitude + " °N";
            _lLatitude.Content = _latitude + " °E";
            _lDepth.Content = _depth + " m";
            _lSog.Content = _sog + " km";
            _lHeading.Content = _heading;
        }
    }
}
