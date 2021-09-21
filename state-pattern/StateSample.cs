using System;
namespace state_pattern
{

    //1 
    public interface ICargoState
    {
        void HandleState(ICargo cargo);
    }

    public interface ICargo
    {
        ICargoState CurrentState { get; set; }
        void ChangeState(ICargoState state);
    }

    //2

    public class PreparingState : ICargoState
    {
        public void HandleState(ICargo cargo)
        {
            // Write Your State Operations
            Console.WriteLine("Your cargo is prepared...");

            cargo.CurrentState = this;
        }
    }

    public class ShippedState : ICargoState
    {
        public void HandleState(ICargo cargo)
        {
            // Write Your State Operations
            Console.WriteLine("Your cargo was shipped...");

            cargo.CurrentState = this;
        }
    }

    public class InTransitState : ICargoState
    {
        public void HandleState(ICargo cargo)
        {
            // Write Your State Operations
            Console.WriteLine("Your cargo is on way...");

            cargo.CurrentState = this;
        }
    }

    public class DeliveredState : ICargoState
    {
        public void HandleState(ICargo cargo)
        {
            // Write Your State Operations
            Console.WriteLine($"Your cargo was delivered {DateTime.Now}");

            cargo.CurrentState = this;
        }
    }

    //3
    public class Cargo : ICargo
    {

        public ICargoState CurrentState { get; set; }

        public Cargo()
        {
            this.ChangeState(new PreparingState());
        }

        public void ChangeState(ICargoState state)
        {
            state.HandleState(this);
        }

    }
}
