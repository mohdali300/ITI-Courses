using System.Reflection;

namespace Day6
{
    internal class Program
    {
        // 1, 2
        delegate double MathOperation(double a, double b);

        // 3
        delegate bool IntFilter(int num);

        static int[] FilterArray(int[] nums, IntFilter filter)
        {
            List<int> filtered = new List<int>();
            foreach (var num in nums)
            {
                if (filter(num))
                {
                    filtered.Add(num);
                }
            }
            return filtered.ToArray();
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        static bool IsOdd(int num)
        {
            return (num % 2 == 1);
        }
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;
            int threshold = (int)Math.Sqrt(num);

            for (int i = 3; i <= threshold; i += 2)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        // 6
        class Person
        {
            public string? Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            #region task 1
            MathOperation add = Calculator.Add;
            var result = add(2, 3);
            Console.WriteLine($"Addition: {result}");

            MathOperation divide = Calculator.Divide;
            result = divide(10, 5);
            Console.WriteLine($"Division: {result}"); 
            #endregion

            #region task 2
            //MathOperation operation = Calculator.Add;
            //operation += Calculator.Subtract;
            //operation += Calculator.Multiply;
            //operation += Calculator.Divide;

            //operation(20, 4);
            //operation -= Calculator.Subtract;
            //Console.WriteLine("-----------------");
            //operation(20, 4);
            #endregion

            #region task 3
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //int[] even = FilterArray(numbers, IsEven);
            //int[] odd = FilterArray(numbers, IsOdd);
            //int[] prime = FilterArray(numbers, IsPrime);

            //foreach (int i in prime)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region task 4
            //IntFilter filter = delegate (int n)
            //{
            //    return n % 2 == 0;
            //};
            //int[] even2 = FilterArray([1, 2, 3, 4, 5], filter);

            //int[] odd2 = FilterArray([1, 2, 3, 4, 5], delegate (int n) { return n % 2 == 1; });
            //foreach (int n in odd2)
            //{
            //    Console.WriteLine(n);
            //}
            #endregion

            #region task 5
            //IntFilter f = n => n % 2 == 0;
            //int[] even3 = FilterArray([1, 2, 3, 4, 5], f);

            //List<int> nums = new() { 1, 2, 3, 4, 5, 6, 7, 8 };
            //Console.WriteLine(
            //    nums.Find(n => n > 4)
            //    );

            //Console.WriteLine(
            //    nums.Exists(n => n == 10)
            //    );
            #endregion

            #region task 6
            //List<Person> people = new()
            //{
            //    new Person {Name="Ali", Age=24},
            //    new Person {Name="Mohamed", Age=30},
            //    new Person {Age=19},
            //    new Person {Name="Amr", Age=26},
            //    new Person {Name="Zeyad", Age=20},
            //};

            //people.Sort((a,b)=>a.Age.CompareTo(b.Age));
            //foreach (Person person in people)
            //{
            //    Console.WriteLine($"{person.Name}, {person.Age}");
            //}

            //Console.WriteLine("----------------");
            //people.Sort((a, b) =>
            //{
            //    var name= a.Name.CompareTo(b.Name);
            //    if(name!=0) return name;
            //    return b.Age.CompareTo(a.Age);
            //});
            //foreach (Person person in people)
            //{
            //    Console.WriteLine($"{person.Name}, {person.Age}");
            //}

            #endregion

            #region task 7
            //TemperatureSensor sensor = new();
            //TemperatureMonitor monitor = new();

            //sensor.TemperatureHigh += monitor.OnHighTemperature;
            //sensor.TemperatureLow += monitor.OnLowTemperature;

            //sensor.SetTemperature(25);
            //sensor.SetTemperature(40);
            //sensor.SetTemperature(8);

            //sensor.TemperatureLow -= monitor.OnLowTemperature;
            //sensor.SetTemperature(5);
            #endregion

            #region task 8
            //Button btn = new("OK");

            //btn.Click += Form.OnButtonClick;
            //btn.Click += Logger.LogClick;
            //btn.Click += (s, n) => Console.WriteLine(n);

            //btn.PerformClick();
            //Console.WriteLine("-------------");
            //btn.Click-=Logger.LogClick;
            //btn.PerformClick();
            #endregion
        }
    }
}
