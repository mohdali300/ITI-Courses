using System;

namespace Lab4
{
    public abstract class Animal
    {
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name;
        }

        public abstract void MakeSound();
        public abstract void Move();

        public virtual void Describe()
        {
            Console.WriteLine($"[{GetType().Name}] Name: {Name}");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }

        public override void Move()
        {
            Console.WriteLine("Runs on four legs.");
        }

        public void Fetch()
        {
            Console.WriteLine($"{Name} fetches the ball.");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }

        public override void Move()
        {
            Console.WriteLine("Walks gracefully and climbs.");
        }

        public void Purr()
        {
            Console.WriteLine($"{Name} purrs contently.");
        }
    }

    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine("Chirp! Chirp!");
        }

        public override void Move()
        {
            Console.WriteLine("Flies through the air.");
        }

        public void FlyHigher()
        {
            Console.WriteLine($"{Name} flaps wings and gains altitude.");
        }
    }
}