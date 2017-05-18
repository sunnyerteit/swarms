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
using System.Windows.Threading;
using System.IO;
using Newtonsoft.Json;

namespace swarmsWpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String sURL = AppDomain.CurrentDomain.BaseDirectory + "html/index.html";


        string _projectName = "Orson";
        string _rovName = "Rosebud";
        TimeSpan _startTime = new TimeSpan(2, 14, 18);
        string _task = "MacGuffin";

        public static double _longitude = 63.433542800000005;
        public static double _latitude = 10.413571;
        bool _lights = true;
        bool _condition = false;
        double _angleCamera1 = 89.9;
        double _angleCamera2 = 50.9;
        public static double _depth = 10.4;
        double _sog = 3.2;
        string _heading = "Home";

        public static double _armDeg1 = 20.9;
        public static double _armDeg2 = 24.9;
        public static double _armDeg3 = 54.9;
        public static double _armDeg4 = 0;


        public static double _direction = 250.6;
        public static double _pitch = 0.0;
        public static double _roll = 0.0;

        public static bool _selfCheck = false;
        static bool _dynPos = false;
        static bool _drive = true;
        static bool _follow = false;


        public MainWindow()
        {
            InitializeComponent();
            displayTime();
            rightTopFrame.Content = new positionPage(_longitude, _latitude, _depth, _sog, _heading);
            rightBotFrame.Content = new gripperPage(_armDeg1,_armDeg2,_armDeg3);
            //rightFrame.Content = new rovControl();

            _rovList dog1 = new _rovList() { nr = 1, lng = 63.4304, lat = 10.39517, depth = 5.6 };
            _rovList dog2 = new _rovList() { nr = 2, lng = 63.4314, lat = 10.39527, depth = 4.6 };
            _rovList dog3 = new _rovList() { nr = 3, lng = 63.4324, lat = 10.39537, depth = 3.6 };
            _rovList dog4 = new _rovList() { nr = 4, lng = 63.4334, lat = 10.39547, depth = 2.6 };
            _rovList dog5 = new _rovList() { nr = 5, lng = 63.4344, lat = 10.39567, depth = 1.6 };



            //If variable map is added:


            string _longitudeStr = _longitude.ToString("0.00000000000000000");
            string _latitudeStr = _latitude.ToString("0.00000000000000000");

            _lProjectName.Content = _projectName;
            _lRovName.Content = _rovName;
            _lStartTime.Content = _startTime;
            _lTask.Content = _task;


            labelTopLeft.Content = "Camera 1:  angle " + _angleCamera1 + "°  / position " + _longitude + " °N " + _latitude + " °E / lights - " + _lights + " / condition - " + _condition;
            labelTopRight.Content = "Camera 2:  angle " + _angleCamera2 + "°  / position " + _longitude + " °N " + _latitude + " °E / lights - " + _lights + " / condition - " + _condition;
        }


        //Displays current time
        private void displayTime()
        {
            _labelClock.Content = DateTime.Now.ToShortTimeString();
        }

        private void rovClick(object sender, RoutedEventArgs e)
        {
            rightBotFrame.Content = new rovPage(_dynPos, _drive, _follow);

            //_bRovButton.Background = Brushes.#FF3C3B4D;
            _bRovButton.Background = new SolidColorBrush(Color.FromArgb(255, 60, 59, 77));
            _bGripperButton.Background = new SolidColorBrush(Color.FromArgb(255, 60, 56, 77));
        }

        private void gripperClick(object sender, RoutedEventArgs e)
        {
            rightBotFrame.Content = new gripperPage(_armDeg1,_armDeg2,_armDeg3);
            _bGripperButton.Background = new SolidColorBrush(Color.FromArgb(255, 60, 59, 77));
            _bRovButton.Background = new SolidColorBrush(Color.FromArgb(255, 60, 56, 77));
        }


        public static void updateDynPos()
        {
            _dynPos = rovPage.dynPos;
            _drive = rovPage.drive;
            _follow = rovPage.follow;
        }

        private void dockPanel1Loaded(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(sURL);
            webBrowser1.Navigate(uri);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(10);
            dt.Tick += dtTicker;
            dt.Start();

            DispatcherTimer dtt = new DispatcherTimer();
            dtt.Interval = TimeSpan.FromMilliseconds(100);
            dtt.Tick += dttTicker;
            dtt.Start();
        }

        public void dttTicker(object sender, EventArgs e)
        {
            Random random = new Random();
            _pitch += increment * 50000 * (random.NextDouble() - 0.5);
            _roll += increment * 50000 * (random.NextDouble() - 0.5);
            _direction += increment * 50000 * (random.NextDouble() - 0.5);
            _armDeg1 += 2 * (random.NextDouble() - 0.5);
            _armDeg2 += 2 * (random.NextDouble() - 0.5);
            _armDeg3 += 2 * (random.NextDouble() - 0.5);
            _armDeg4 += 2;
        }


        //Need to structure better
        public class _rovList
        {
            public int nr;
            public double lng;
            public double lat;
            public double depth;
        }




        private double increment = 0;

        public void dtTicker(object sender, EventArgs e)
        {
            double[] _jsonMarker = new double[] { 63.43045 + increment, 10.39517 + increment, 63.44155, 10.39517, 63.43155, 10.39627 , 63.43035 , 10.39507 };
            double[] _jsonDepth = new double[] { 3.6 + increment * 1000, 1.6 + increment * (-1000), 2.6 + increment * (-100) , 0.0 + increment * 10000 };
            double[] _jsonRoute = new double[] { 63.43045 , 10.39517 , 63.44155, 10.39517, 63.43155, 10.39627 };
            string outputJson = JsonConvert.SerializeObject(_jsonRoute);
            string outputJsonDepth = JsonConvert.SerializeObject(_jsonDepth);
            string outputJson2 = JsonConvert.SerializeObject(_jsonMarker);

            Random random = new Random();

            _longitude = _jsonMarker[0];
            _latitude = _jsonMarker[1];
            _depth = _jsonDepth[0];


            //rovPage.PitchRoll();

            rightTopFrame.Content = new positionPage(_longitude, _latitude, _depth, _sog, _heading);
            string _longitudeStr = _longitude.ToString("0.00000000000000000");
            string _latitudeStr = _latitude.ToString("0.00000000000000000");

            labelTopLeft.Content = "Camera 1:  angle " + _angleCamera1 + "°  / position " + _longitude + " °N " + _latitude + " °E / lights - " + _lights + " / condition - " + _condition;
            labelTopRight.Content = "Camera 2:  angle " + _angleCamera2 + "°  / position " + _longitude + " °N " + _latitude + " °E / lights - " + _lights + " / condition - " + _condition;

            webBrowser1.InvokeScript("_jsonRoute", new Object[] { outputJson });
            increment += 0.00001;
            webBrowser1.InvokeScript("deleteMarkers", new Object[] { });
            webBrowser1.InvokeScript("_markerList", new Object[] { outputJson2, outputJsonDepth });

        }
            //public static void updatePos(_dynPos, )
            //{
            //    rovPage.dynPos(_dynPos);
            //}

            //public void mainGetPositionMethod()
            //{
            //    _dynPos = rovPage.

            //}


        }
    }
