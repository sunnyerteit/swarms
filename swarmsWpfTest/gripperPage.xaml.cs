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
using System.Windows.Threading;

namespace swarmsWpfTest
{
    /// <summary>
    /// Interaction logic for gripperPage.xaml
    /// </summary>
    public partial class gripperPage : Page
    {
        public gripperPage(double deg1, double deg2, double deg3)
        {
            InitializeComponent();
            _gripperFrame1.Content = new _gripperPage1(deg1, deg2, deg3);
            _gripperFrame2.Content = new _gripperPage2(deg1, deg2, deg3);
            _gripperFrame3.Content = new _gripperPage3(deg1, deg2, deg3);
            updateArm();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }


        void timer_Tick(object sender, EventArgs e)
        {
            ScaleTransform scaleTransform1 = new ScaleTransform(1, MainWindow._armDeg1 / 360.0, 0.5, 1.0);
            _rDeg1.RenderTransform = scaleTransform1;
            ScaleTransform scaleTransform2 = new ScaleTransform(1, MainWindow._armDeg2 / 360.0, 0.5, 1.0);
            _rDeg2.RenderTransform = scaleTransform2;
            ScaleTransform scaleTransform3 = new ScaleTransform(1, MainWindow._armDeg4 / 360.0, 0.5, 1.0);
            _rDeg3.RenderTransform = scaleTransform3;
        }

        private void updateArm()
        {
            ScaleTransform scaleTransform1 = new ScaleTransform(1, MainWindow._armDeg1 / 360.0, 0.5, 1.0);
            _rDeg1.RenderTransform = scaleTransform1;
            ScaleTransform scaleTransform2 = new ScaleTransform(1, MainWindow._armDeg2 / 360.0, 0.5, 1.0);
            _rDeg2.RenderTransform = scaleTransform2;
            ScaleTransform scaleTransform3 = new ScaleTransform(1, MainWindow._armDeg4 / 360.0, 0.5, 1.0);
            _rDeg3.RenderTransform = scaleTransform3;
        }
    }
}
