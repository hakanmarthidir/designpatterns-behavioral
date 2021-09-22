using System;
namespace visitor_pattern
{
    public interface IGameConsole
    {
        DateTime ReleaseDate { get; set; }
        double Price { get; set; }
        void Accept(IVisitor visitor);
    }

    public class XboxSeriesX : IGameConsole
    {
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Ps5 : IGameConsole
    {
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    // Visitor Part

    public interface IVisitor
    {
        void Visit(XboxSeriesX xboxSeriesX);
        void Visit(Ps5 ps5);
    }

    public class ConsoleWheelVisitor : IVisitor
    {
        public void Visit(XboxSeriesX xboxSeriesX)
        {
            Console.WriteLine("xbox wheel connected");
        }

        public void Visit(Ps5 ps5)
        {
            Console.WriteLine("ps5 wheel connected");
        }
    }
}
