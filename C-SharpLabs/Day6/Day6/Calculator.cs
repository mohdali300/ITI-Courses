using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Calculator
    {

        public static double Add(double a, double b)
        {
            Console.WriteLine("Performing Addition");
            return a + b;
        }
        public static double Subtract(double a, double b)
        {
            Console.WriteLine("Performing Subtraction");
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            Console.WriteLine("Performing Multiplication");
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            try
            {
                Console.WriteLine("Performing Division");
                return a / b;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero is not allowed.");
                return double.NaN;
            }
        }
    }
}
