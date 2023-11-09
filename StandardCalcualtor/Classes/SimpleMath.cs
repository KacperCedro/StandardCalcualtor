using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StandardCalcualtor.Classes
{
    public class SimpleMath
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }
        public static double Substraction(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b) 
        { 
            if (b == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            else 
            {
                return a / b;
            } 
        }
    }
}
