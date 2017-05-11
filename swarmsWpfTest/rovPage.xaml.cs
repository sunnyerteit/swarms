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
    /// Interaction logic for rovPage.xaml
    /// </summary>
    public partial class rovPage : Page
    {
        public rovPage(bool _dynPos, bool _drive, bool _follow)
        {
            InitializeComponent();
            if (_dynPos == true)
            {
                _rDynPos.IsChecked = true;
            }
            else if (_drive == true)
            {
                _rDrive.IsChecked = true;
            }
            else if (_follow == true)
            {
                _rFollow.IsChecked = true;
            }
        }
    }
}
