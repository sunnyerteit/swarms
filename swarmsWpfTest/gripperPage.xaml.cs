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
    /// Interaction logic for gripperPage.xaml
    /// </summary>
    public partial class gripperPage : Page
    {
        public gripperPage()
        {
            InitializeComponent();
            _gripperFrame1.Content = new _gripperPage1();
            _gripperFrame2.Content = new _gripperPage2();
        }
    }
}
