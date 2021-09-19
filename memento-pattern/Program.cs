using System;

namespace memento_pattern
{
    class Program
    {
        static void Main(string[] args)
        {

            GodOfWar godOfWar = new GodOfWar() { Level=1, EarnPoint= 0, MapPoint="Home" };
            Console.WriteLine($"Initial Values {godOfWar.Level} { godOfWar.EarnPoint} {godOfWar.MapPoint}");

            //After Played
            godOfWar.Level = 3;
            godOfWar.EarnPoint = 15000;
            godOfWar.MapPoint = "Mountain";
            Console.WriteLine($"Current Values {godOfWar.Level} { godOfWar.EarnPoint} {godOfWar.MapPoint}");

            //Save the Game
            MementoCareTaker mementoCareTaker = new MementoCareTaker();
            mementoCareTaker.GodOfWarMemento = godOfWar.Save();
            Console.WriteLine("Game Saved...");

            //After Played
            godOfWar.Level = 5;
            godOfWar.EarnPoint = 23000;
            godOfWar.MapPoint = "Forest";
            Console.WriteLine($"Current Values {godOfWar.Level} { godOfWar.EarnPoint} {godOfWar.MapPoint}");

            //Load Check Point
            godOfWar.LoadSavedPoint(mementoCareTaker.GodOfWarMemento);
            Console.WriteLine($"Reload Values {godOfWar.Level} { godOfWar.EarnPoint} {godOfWar.MapPoint}");

        }
    }
}
