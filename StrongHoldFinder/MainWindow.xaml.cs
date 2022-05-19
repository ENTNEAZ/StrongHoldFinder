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
            List<double> re = new()
            {
                double.NaN,
                double.NaN
            };//初始化为不存在

            if (this.method == -1) 
            {
                MessageBox.Show("没有选择方法,请选择一个方法", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                if (this.method == 1)
                {
                    re = Utils.solve(
                        Math.Tan(Math.PI * -1 * Convert.ToDouble(this.FirstFirstDirection.Text) / 180),
                        -1,
                        Math.Tan((-1 * Convert.ToDouble(this.FirstFirstDirection.Text)) * Math.PI / 180) * Convert.ToDouble(this.FirstFirstZ1Location.Text) - Convert.ToDouble(this.FirstFirstX1Location.Text),
                        Math.Tan((-1 * Convert.ToDouble(this.FirstSecondDirection.Text)) * Math.PI / 180),
                        -1,
                        Math.Tan((-1 * Convert.ToDouble(this.FirstSecondDirection.Text))) * Math.PI / 180 * Convert.ToDouble(this.FirstSecondZ1Location.Text) - Convert.ToDouble(this.FirstFirstX1Location.Text)
                        );
                }

                if (this.method == 2)
                {
                    double k1 = (Convert.ToDouble(this.SecondFirstThrowLocationX.Text) - Convert.ToDouble(this.SecondFirstDropLocationX.Text)) / (Convert.ToDouble(this.SecondFirstThrowLocationZ.Text) - Convert.ToDouble(this.SecondFirstDropLocationZ.Text));
                    double k2 = (Convert.ToDouble(this.SecondSecondThrowLocationX.Text) - Convert.ToDouble(this.SecondSecondDropLocationX.Text)) / (Convert.ToDouble(this.SecondSecondThrowLocationZ.Text) - Convert.ToDouble(this.SecondSecondDropLocationZ.Text));
                    re = Utils.solve(k1, -1, k1 * Convert.ToDouble(this.SecondFirstThrowLocationZ.Text) - Convert.ToDouble(this.SecondFirstThrowLocationX.Text), k2, -1, k2 * Convert.ToDouble(this.SecondSecondThrowLocationZ.Text) - Convert.ToDouble(this.SecondSecondThrowLocationX.Text));

                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入数据有误，请检查输入", "注意", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            

            if (double.IsNaN(re[0]) || double.IsNaN(re[1])) 
            {
                //方程无法求解
                MessageBox.Show("两点过近或数据错误，请重新尝试。", "注意", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.ShowLocationX.Content = "X:" + re[1].ToString();
            this.ShowLocationZ.Content = "Z:" + re[0].ToString();
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
