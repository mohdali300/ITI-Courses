using System.Collections;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 1
            //Person p1 = new Person();
            //p1.ShowPersonInfo();

            //Person p2 = new Person
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Age = 30,
            //    Address = new Address
            //    {
            //        Street = "123 Main St",
            //        City = "Anycity",
            //        State = "CA"
            //    }
            //};
            //p2.ShowPersonInfo();
            #endregion

            #region task 2
            //Rectangle rect1 = new Rectangle
            //{
            //    Width = 5.0,
            //    Height = 10.0,
            //    Color = "Red",
            //    Unit = "cm"
            //};
            //rect1.DisplayInfo();
            #endregion

            #region task 3
            //GradeBook gb = new GradeBook(3);
            //gb[0] = 85;
            //gb[1] = 90;
            //gb[2] = 78;

            //gb.DisplayGrade();
            #endregion

            #region task 4
            //StringCollection s1 = new StringCollection(3);
            //s1[0] = "First";
            //s1[1] = "Second";
            //s1.DisplayItems();

            //s1["A"] = "localhost";
            //s1["B"] = "8080";
            //s1["C"] = "it’s ok";
            //s1.DisplayKeys();
            #endregion

            #region task 5
            //ArrayList cart = new ArrayList();
            //cart.Add(10);
            //cart.Add("Apple");
            //cart.Add(15.5);
            //cart.Add(true);

            //foreach (var item in cart)
            //{
            //    Console.WriteLine($"Item: {item}, Type: {item.GetType()}");
            //}

            //cart.Reverse();
            //cart.RemoveAt(2);
            //cart.Insert(1, "Banana");
            ////cart.Sort();

            //foreach (var item in cart)
            //{
            //    Console.WriteLine($"Item: {item}, Type: {item.GetType()}");
            //}
            #endregion

            #region task 6 (with person)
            //List<Person> people = new List<Person>
            //{
            //    new Person("Alice", "Smith", 28, new Address("456 Oak St", "Somecity", "NY")),
            //    new Person("Bob", "Johnson", 35, new Address("789 Pine St", "Othertown", "TX")),
            //    new Person("Charlie", "Brown", 22, new Address("101 Maple St", "Anycity", "FL"))
            //};

            //people.Find(p=>p.FirstName=="Bob")?.ShowPersonInfo();
            //Console.WriteLine("-------------------");
            //people.FindAll(p=>p.Age>25).ForEach(p=>p.ShowPersonInfo());
            //Console.WriteLine("-------------------");
            //people.Sort((p1, p2) => p1.Age.CompareTo(p2.Age));
            //foreach (var person in people)
            //{
            //    person.ShowPersonInfo();
            //    Console.WriteLine("---");
            //}
            #endregion

            #region task 7
            //Console.WriteLine(Calculator.Divide(10, 2));

            //try
            //{
            //    Calculator.Divide(10, 0);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            #endregion

            #region task 8
            try
            {
                string data = FileChecker.ReadAndThrowIfContainsError("data.txt");
                Console.WriteLine("File ok. Length: " + data.Length);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"Validation failed: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finished file check.");
            }
            #endregion
        }
    }
}
