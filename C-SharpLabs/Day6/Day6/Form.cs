using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Form
    {
        public static void OnButtonClick(object sender, string buttonName)
        {
            Console.WriteLine($"received click from '{buttonName}' (sender: {sender.GetType().Name})");
        }
    }

    public class Logger
    {
        public static void LogClick(object sender, string buttonName)
        {
            Console.WriteLine($"[Log] Button clicked: {buttonName}");
        }
    }
}
