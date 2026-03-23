using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Date
    {
        int Year;
        int Month;
        int Day;


        public Date(): this(1, 1, 1990)
        {
        }

        public Date(int year) : this(1, 1, year)
        {
        }

        public Date(int month, int year) : this(1, month, year)
        {
        }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public void ShowDate()
        {
            Console.WriteLine($"{Day}/{Month}/{Year}");
        }
    }
}
