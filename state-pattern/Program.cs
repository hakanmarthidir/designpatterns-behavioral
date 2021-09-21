using System;

namespace state_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICargo myCargo = new Cargo();

            myCargo.ChangeState(new InTransitState());
            myCargo.ChangeState(new DeliveredState());
        }
    }
}
