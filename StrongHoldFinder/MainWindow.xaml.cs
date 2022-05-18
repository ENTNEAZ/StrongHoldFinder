using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private int method = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SingleLocationWithDirection_Checked(object sender, RoutedEventArgs e)
        {
            //一对坐标视角
            this.method = 1;
        }

        private void DoubleLocation_Checked(object sender, RoutedEventArgs e)
        {
            //双坐标
            this.method = 2;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            List<double>? re;
            if (this.method == -1) 
            {
                MessageBox.Show("没有选择方法,请选择一个方法", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (this.method == 1) 
            {
                re = Utils.solve(
                    Math.Tan(Math.PI * -1 * Convert.ToDouble(this.FirstFirstDirection.Text) / 180),
                    -1,
                    Math.Tan((-1 * Convert.ToDouble(this.FirstFirstDirection.Text)) * Math.PI / 180) * Convert.ToDouble(this.FirstFirstZ1Location.Text) - Convert.ToDouble(this.FirstFirstX1Location.Text), 
                    Math.Tan((-1 * Convert.ToDouble(this.FirstSecondDirection.Text)) * Math.PI / 180),
                    -1,
                    Math.Tan((-1 * Convert.ToDouble(this.FirstSecondDirection.Text))) * Math.PI/180 * Convert.ToDouble(this.FirstSecondZ1Location.Text) - Convert.ToDouble(this.FirstFirstX1Location.Text)
                    );
            }

            if (this.method == 2) 
            {
                
            }
        }
        private bool CheckAllFirstTextBox()
        {
            //检查左侧有没有东西写进去了
            if (this.FirstFirstX1Location.Text != "0") 
                return true;
            if (this.FirstFirstZ1Location.Text != "0")
                return true;
            if (this.FirstFirstDirection.Text != "0")
                return true;
            if (this.FirstSecondX1Location.Text != "0")
                return true;
            if (this.FirstSecondZ1Location.Text != "0")
                return true;
            if (this.FirstSecondDirection.Text != "0")
                return true;

            return false;
        }

        private bool CheckAllSecondTextBox()
        {
            //检查右侧有没有东西写进去了
            if (this.SecondFirstThrowLocationX.Text != "0")
                return true;
            if (this.SecondFirstThrowLocationZ.Text != "0")
                return true;
            if (this.SecondFirstDropLocationX.Text != "0")
                return true;
            if (this.SecondFirstDropLocationZ.Text != "0")
                return true;

            if (this.SecondSecondThrowLocationX.Text != "0")
                return true;
            if (this.SecondSecondThrowLocationZ.Text != "0")
                return true;
            if (this.SecondSecondDropLocationX.Text != "0")
                return true;
            if (this.SecondFirstDropLocationZ.Text != "0")
                return true;

            return false;
        }
    }
}
