using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Color { get; set; } = "White";
        public string Unit { get; set; } = "cm";
        public int Id { get; }
        public double Area => Width * Height;

        public Rectangle()
        {
            Width = 10;
            Height = 10;
            Id = new Random().Next(1, 100);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Rectangle ID: {Id}\nWidth: {Width} {Unit}\nHeight: {Height} {Unit}\nColor: {Color}\nArea: {Area} {Unit}²");
        }
    }
}
