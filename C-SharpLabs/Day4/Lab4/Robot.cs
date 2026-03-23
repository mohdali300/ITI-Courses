using System;

namespace Lab4
{
    public class Robot : IMovable, IChargeable
    {
        private int _speed;
        private int _batteryLevel;
        public string Id { get; }

        public Robot(string id, int initialBattery = 100)
        {
            Id = id ?? "Robot";
            _batteryLevel = Math.Clamp(initialBattery, 0, 100);
            _speed = 0;
        }

        public void Move()
        {
            if (_batteryLevel <= 0)
            {
                Console.WriteLine($"{Id} cannot move — battery is empty.");
                _speed = 0;
                return;
            }

            _speed = 5;
            _batteryLevel = Math.Max(0, _batteryLevel - 5);
            Console.WriteLine($"{Id} moves at {_speed} km/h. Battery: {_batteryLevel}%");
        }

        public void Stop()
        {
            _speed = 0;
            Console.WriteLine($"{Id} has stopped.");
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public void Charge(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"{Id}: Charge amount must be positive.");
                return;
            }

            _batteryLevel = Math.Clamp(_batteryLevel + amount, 0, 100);
            Console.WriteLine($"{Id} charged. Battery: {_batteryLevel}%");
        }

        public int GetBatteryLevel()
        {
            return _batteryLevel;
        }
    }
}