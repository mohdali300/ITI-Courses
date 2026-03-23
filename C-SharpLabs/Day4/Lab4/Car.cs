using System;

namespace Lab4
{
    public class Car : IMovable
    {
        private int _speed;
        public string Model { get; }

        public Car(string model)
        {
            Model = model ?? "Unknown";
            _speed = 0;
        }

        public void Move()
        {
            _speed = 60;
            Console.WriteLine($"{Model} is moving at {_speed} km/h.");
        }

        public void Stop()
        {
            _speed = 0;
            Console.WriteLine($"{Model} has stopped.");
        }

        public int GetSpeed()
        {
            return _speed;
        }
    }
}