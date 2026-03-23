using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public delegate void TemperatureHandler (string msg, double temp);
    public class TemperatureSensor
    {
        //double Temperature { get; set; }

        public event TemperatureHandler TemperatureHigh;
        public event TemperatureHandler TemperatureLow;

        public void SetTemperature(double temp)
        {
            if (temp > 30)
            {
                if (TemperatureHigh != null)
                    TemperatureHigh("Warning! High temp ", temp);
            }
            else if (temp < 10)
            {
                if (TemperatureLow != null)
                    TemperatureLow("Warning! Low temp ", temp);
            }
            else
            {
                Console.WriteLine($"Temp Changed: {temp}");
            }
        }


    }
}
