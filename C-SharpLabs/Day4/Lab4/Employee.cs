using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public double Salary { get; }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Salary: {Salary:C}");
        }
    }

    public class Manager : Employee
    {
        public double Bonus { get; }

        public Manager(int id, string name, double salary, double bonus)
            : base(id, name, salary)
        {
            Bonus = bonus;
        }

        public void DisplayManagerInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Bonus: {Bonus:C}, Total Compensation: {(Salary + Bonus):C}");
        }
    }

    public class Developer : Employee
    {
        public string ProgrammingLanguage { get; }

        public Developer(int id, string name, double salary, string programmingLanguage)
            : base(id, name, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public void DisplayDeveloperInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Primary Language: {ProgrammingLanguage}");
        }
    }

    public class Intern : Employee
    {
        public string School { get; }
        public double Stipend { get; }

        public Intern(int id, string name, double stipend, string school)
            : base(id, name, stipend)
        {
            Stipend = stipend;
            School = school;
        }

        public void DisplayInternInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"School: {School}, Stipend: {Stipend:C}");
        }
    }
}
