using System;

namespace Lab4
{
    public class Shape
    {
        public virtual double CalculateArea() => 0.0;
        public virtual double CalculatePerimeter() => 0.0;

        public virtual void Display()
        {
            Console.WriteLine($"Area: {CalculateArea():F2}, Perimeter: {CalculatePerimeter():F2}");
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius < 0) throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");
            Radius = radius;
        }

        public override double CalculateArea() => Math.PI * Radius * Radius;
        public override double CalculatePerimeter() => 2 * Math.PI * Radius;

        public override void Display()
        {
            Console.WriteLine($"Circle (radius: {Radius})");
            base.Display();
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
        }

        public override double CalculateArea() => Width * Height;
        public override double CalculatePerimeter() => 2 * (Width + Height);

        public override void Display()
        {
            Console.WriteLine($"Rectangle (width: {Width}, height: {Height})");
            base.Display();
        }
    }

    public class Triangle : Shape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Triangle(double a, double b, double c)
        {
            A = a; B = b; C = c;
            if (A <= 0 || B <= 0 || C <= 0 ||
                A + B <= C || A + C <= B || B + C <= A)
            {
                throw new ArgumentException("Invalid triangle sides.");
            }
        }

        public override double CalculatePerimeter() => A + B + C;

        public override double CalculateArea()
        {
            double s = CalculatePerimeter() / 2.0;
            double areaSquared = s * (s - A) * (s - B) * (s - C);
            return areaSquared <= 0 ? 0.0 : Math.Sqrt(areaSquared);
        }

        public override void Display()
        {
            Console.WriteLine($"Triangle (a: {A}, b: {B}, c: {C})");
            base.Display();
        }
    }
}