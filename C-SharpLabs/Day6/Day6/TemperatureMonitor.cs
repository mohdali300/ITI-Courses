using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class TemperatureMonitor
    {

        public void OnHighTemperature(string msg, double temp)
        {
            Console.WriteLine($"Alert: {temp}°C - {msg}");
        }

        public void OnLowTemperature(string msg, double temp)
        {
            Console.WriteLine($"Alert: {temp}°C - {msg}");
        }
    }
}
