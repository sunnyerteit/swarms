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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            displayTime();
        }

        //Displays current time
        private void displayTime()
        {
            _labelClock.Content = DateTime.Now.ToShortTimeString();
        }

        private void rovClick(object sender, RoutedEventArgs e)
        {
            rightFrame.Content = new rovControl();
        }

        private void gripperClick(object sender, RoutedEventArgs e)
        {
            rightFrame.Content = new gripperControl();
        }
    }
}
