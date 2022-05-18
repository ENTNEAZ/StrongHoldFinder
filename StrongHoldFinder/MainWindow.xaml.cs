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

namespace StrongHoldFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int method = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SingleLocationWithDirection_Checked(object sender, RoutedEventArgs e)
        {
            this.method = 1;
        }

        private void DoubleLocation_Checked(object sender, RoutedEventArgs e)
        {
            this.method = 2;
        }

        private List<double> solve(double a, double b, double c,double d, double e, double f)
        {

            double y = (f - d * c / a) / (e - d * b / a);
            double x = (c - b * y) / a;
            List<double> result = new()
            {
                x,
                y
            };
            return result;
        }
    }
}
