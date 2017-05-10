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
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;

namespace swarmsWpfTest
{
    /// <summary>
    /// Interaction logic for _gripperPage1.xaml
    /// </summary>
    public partial class _gripperPage1 : Page
    {
        Model3DGroup RA = new Model3DGroup();
        Model3D link1 = null;
        Model3D link2 = null;
        public _gripperPage1()
        {
            InitializeComponent();
        }
    }
}
