using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongHoldFinder
{
    class Utils
    {
        public static List<double>? solve(double a, double b, double c, double d, double e, double f)
        {
            //解个方程用
            try
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
            catch (Exception)
            {
                return null;
            }
            
           
        }
    }
}
