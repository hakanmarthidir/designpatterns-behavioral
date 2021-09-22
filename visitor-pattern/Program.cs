using System;

namespace visitor_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWheelVisitor consoleFeatureVisitor = new ConsoleWheelVisitor();

            XboxSeriesX xboxSeriesX = new XboxSeriesX();
            xboxSeriesX.Accept(consoleFeatureVisitor);

            Ps5 ps5 = new Ps5();
            ps5.Accept(consoleFeatureVisitor);

        }
    }
}
