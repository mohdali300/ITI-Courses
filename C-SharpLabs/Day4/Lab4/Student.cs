using System;

namespace Lab4
{
    public class Student
    {
        private int _age;
        private double _gpa;
        private string? _name;

        public int Id { get; }

        public string Name
        {
            get => _name ?? string.Empty;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Trim().Length >= 2)
                    _name = value.Trim();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value >= 16 && value <= 100)
                    _age = value;
            }
        }

        public double GPA
        {
            get => _gpa;
            set
            {
                if (value >= 0.0 && value <= 4.0)
                    _gpa = Math.Round(value, 2);
            }
        }

        public Student(int id, string name, int age, double gpa)
        {
            Id = id;
            Name = name;
            Age = age;
            GPA = gpa;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Student(Id: {Id}, Name: {Name}, Age: {Age}, GPA: {GPA:F2})");
        }
    }
}