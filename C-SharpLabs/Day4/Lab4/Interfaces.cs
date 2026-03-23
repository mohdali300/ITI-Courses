using System;

namespace Lab4
{
    public interface IMovable
    {
        void Move();
        void Stop();
        int GetSpeed();
    }

    public interface IChargeable
    {
        void Charge(int amount);
        int GetBatteryLevel();
    }
}