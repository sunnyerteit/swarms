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
using System.Diagnostics;

namespace swarmsWpfTest
{
    /// <summary>
    /// Interaction logic for rovPage.xaml
    /// </summary>
    public partial class rovPage : Page
    {
        public static bool dynPos = false;
        public static bool drive = false;
        public static bool follow = false;

        public static bool selfCheck = false;
            
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

            if (MainWindow._selfCheck == false)
            {
                _cStatusSelfCheck.IsChecked = false;
            }
            else
            {
                _cStatusSelfCheck.IsChecked = true;
            }

            dynPos = _dynPos; 
            drive = _drive;
            follow = _follow;

            updateDegrees();
            updatePitchRoll();

        }

        private void _checkDynPos(object sender, RoutedEventArgs e)
        {

            _rDynPos.IsChecked = true;
            dynPos = true;
            drive = false;
            follow = false;
            MainWindow.updateDynPos();

        }


        private void _checkDrive(object sender, RoutedEventArgs e)
        {
            _rDrive.IsChecked = true;
            dynPos = false;
            drive = true;
            follow = false;
            MainWindow.updateDynPos();
        }



        private void _checkFollow(object sender, RoutedEventArgs e)
        {
            _rFollow.IsChecked = true;
            dynPos = false;
            drive = false;
            follow = true;
            MainWindow.updateDynPos();
        }
        

        //Updates the compass in rovPage.xaml
        private void updateDegrees()
        {
            _lCompassDegrees.Content = MainWindow._direction.ToString("0.");
            RotateTransform rotateTransform = new RotateTransform( - MainWindow._direction + 45);
            _iDynamicCompass.RenderTransform = rotateTransform;
            if (MainWindow._direction % 360 < 22.5)
            {
                _lADirection.Content = "NORTH";
            }
            else if (MainWindow._direction % 360 < 67.5)
            {
                _lADirection.Content = "NORTHEAST";
            }
            else if (MainWindow._direction % 360 < 112.5)
            {
                _lADirection.Content = "EAST";
            }
            else if (MainWindow._direction % 360 < 157.5)
            {
                _lADirection.Content = "SOUTHEAST";
            }
            else if (MainWindow._direction % 360 < 202.5)
            {
                _lADirection.Content = "SOUTH";
            }
            else if (MainWindow._direction % 360 < 247.5)
            {
                _lADirection.Content = "SOUTHWEST";
            }
            else if (MainWindow._direction % 360 < 292.5)
            {
                _lADirection.Content = "WEST";
            }
            else if (MainWindow._direction % 360 < 337.5)
            {
                _lADirection.Content = "NORTHWEST";
            }
            else
            {
                _lADirection.Content = "NORTH";
            }
        }

        private void updatePitchRoll()
        {
            RotateTransform rotateTransform = new RotateTransform(MainWindow._roll);
            _iPitchRoll.RenderTransform = rotateTransform;

            if (MainWindow._pitch % 360 < 2.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr0.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 7.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr0.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 12.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr10.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 17.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr10.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 22.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr20.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 27.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr20.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 180.0)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr30.png", UriKind.Relative));
            }
            //////////////////////
            else if (MainWindow._pitch % 360 < 332.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnrn30.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 337.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnrn30.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 342.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnrn20.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 347.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnrn20.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 352.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnrn10.png", UriKind.Relative));
            }
            else if (MainWindow._pitch % 360 < 357.5)
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnrn10.png", UriKind.Relative));
            }
            else
            {
                _iPitchRoll.Source = new BitmapImage(new Uri(@"image/_pnr0.png", UriKind.Relative));
            }
        }


        ///

        private void _cStatusChecked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("ctext");

            MainWindow._selfCheck = true;
        }

        private void _cStatusUnchecked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("utext");

            MainWindow._selfCheck = false;
        }

        //public static void updatePosMet(bool p_dynPos, bool p_drive, bool p_follow)
        //{
        //    p_dynPos = dynPos;
        //    p_drive = drive;
        //    p_follow = follow;
        //}


    }
}
