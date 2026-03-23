using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public Person()
        {
            FirstName = "NA";
            LastName = "NA";
            Age = 0;
            Address = new Address();
        }

        public Person(string firstName, string lastName, int age, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
        }


        public void ShowPersonInfo()
        {
            Console.WriteLine($"First Name: {FirstName},\nLast Name: {LastName},\nAge: {Age}," +
                $"\nAddress: {Address.Street}, {Address.City}, {Address.State}");
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Address()
        {
        }

        public Address(string street, string city, string state)
        {
            Street = street;
            City = city;
            State = state;
        }
    }
}
