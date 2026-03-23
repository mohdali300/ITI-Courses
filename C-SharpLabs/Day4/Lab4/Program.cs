using System;
using System.Runtime.ConstrainedExecution;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 1
            //Date date1 = new Date();
            //date1.ShowDate();
            //Date date2 = new Date(1, 8, 2024);
            //date2.ShowDate();
            //Date date3 = new Date(8, 2024);
            //date3.ShowDate();
            //Date date4 = new Date(2024);
            //date4.ShowDate();
            #endregion

            #region task 2
            Counter c1 = new Counter();
            Counter c2 = new Counter();
            Counter c3 = new Counter();

            Console.WriteLine($"Total objects created: {Counter.totalObjectsCreated}");

            Console.WriteLine($"c1.instanceId: {c1.instanceId}");
            Console.WriteLine($"c2.instanceId: {c2.instanceId}");
            Console.WriteLine($"c3.instanceId: {c3.instanceId}");
            #endregion

            #region task 3
            Manager mgr = new Manager(101, "Ahmed", 8000, 2000);
            Console.WriteLine();
            mgr.DisplayInfo();
            mgr.DisplayManagerInfo();

            Developer dev = new Developer(102, "Sara", 7000, "C#");
            Console.WriteLine();
            dev.DisplayInfo();
            dev.DisplayDeveloperInfo();

            Intern intern = new Intern(103, "Liam", 800, "State University");
            Console.WriteLine();
            intern.DisplayInfo();
            intern.DisplayInternInfo();
            #endregion

            #region task 4
            //Shape s1 = new Circle(5);
            //Shape s2 = new Rectangle(4, 6);
            //Shape s3 = new Triangle(3, 4, 5);

            //Shape[] shapes = { s1, s2, s3 };

            //foreach (var s in shapes)
            //{
            //    Console.WriteLine();
            //    s.Display();
            //}
            #endregion

            #region task 5
            //Animal aDog = new Dog("Rex");
            //Animal aCat = new Cat("Whiskers");
            //Animal aBird = new Bird("Tweety");

            //Animal[] animals = { aDog, aCat, aBird };

            //foreach (var a in animals)
            //{
            //    a.Describe();
            //    a.MakeSound();
            //    a.Move();
            //    Console.WriteLine();
            //}

            //if (aDog is Dog concreteDog)
            //{
            //    concreteDog.Fetch();
            //}

            //if (aCat is Cat concreteCat)
            //{
            //    concreteCat.Purr();
            //}

            //if (aBird is Bird concreteBird)
            //{
            //    concreteBird.FlyHigher();
            //}
            #endregion

            #region task 6
            //var car = new Car("Toyota Corolla");
            //var robot = new Robot("R2-D2", initialBattery: 20);

            //car.Move();
            //Console.WriteLine($"Car speed: {car.GetSpeed()} km/h");
            //car.Stop();
            //Console.WriteLine($"Car speed after stop: {car.GetSpeed()} km/h");

            //Console.WriteLine();

            //robot.Move();
            //Console.WriteLine($"Robot speed: {robot.GetSpeed()} km/h");
            //Console.WriteLine($"Robot battery: {robot.GetBatteryLevel()}%");

            //robot.Move();
            //Console.WriteLine($"Robot battery after second move: {robot.GetBatteryLevel()}%");

            //robot.Stop();
            //Console.WriteLine();

            //robot.Charge(50);
            //Console.WriteLine($"Robot battery after charging: {robot.GetBatteryLevel()}%");

            //robot.Move();
            //Console.WriteLine($"Robot speed after charge & move: {robot.GetSpeed()} km/h");
            #endregion

            #region task 7
            var student = new Student(1, "Alice", 20, 3.5);
            student.DisplayInfo();

            student.Age = 10;
            Console.WriteLine($"Age after invalid set: {student.Age}");

            student.Age = 21;
            Console.WriteLine($"Age after valid set: {student.Age}");

            student.GPA = 4.5;
            Console.WriteLine($"GPA after invalid set: {student.GPA:F2}");

            student.GPA = 3.9;
            Console.WriteLine($"GPA after valid set: {student.GPA:F2}");

            student.Name = " ";
            Console.WriteLine($"Name after invalid set: '{student.Name}'");

            student.Name = "Bob";
            Console.WriteLine($"Name after valid set: '{student.Name}'");
            #endregion

            #region task 8
            var savings = new SavingsAccount("Ahmed", initialBalance: 1000.0, interestRate: 0.05, minimumBalance: 200.0);
            savings.PrintDetails();

            savings.Deposit(500);
            savings.Withdraw(200);
            savings.ApplyInterest();
            savings.PrintDetails();

            Console.WriteLine();

            var checking = new CheckingAccount("Sara", initialBalance: 200.0, overdraftLimit: 300.0);
            checking.PrintDetails();

            checking.Withdraw(350);
            checking.PrintDetails();

            checking.Deposit(500);
            checking.PrintDetails();

            #endregion

        }

    }
}
