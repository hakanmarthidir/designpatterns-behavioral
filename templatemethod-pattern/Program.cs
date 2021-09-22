using System;

namespace templatemethod_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BasketballPlayer basketballPlayer = new BasketballPlayer();
            basketballPlayer.PrepareToMatch();

            TennisPlayer tennisPlayer = new TennisPlayer();
            tennisPlayer.PrepareToMatch();

        }
    }
}
