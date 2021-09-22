using System;
namespace templatemethod_pattern
{
    //Template Design
    public abstract class AthleteTemplate
    {
        //no need to change Eat and Drink processes.. if you need you can set as abstract or override the process. 
        public void Eat()
        {
            Console.WriteLine("Eat Healthy things..");
        }

        public void Drink()
        {
            Console.WriteLine("Drink Healthy things..");
        }
        public abstract void Practice();
        public abstract void Sleep();

        //Template Method
        public void PrepareToMatch()
        {
            this.Eat();
            this.Drink();
            this.Sleep();
            this.Practice();
        }

    }

    //Basketball Player
    public class BasketballPlayer : AthleteTemplate
    {

        public override void Practice()
        {
            Console.WriteLine("6 hours practice");
        }

        public override void Sleep()
        {
            Console.WriteLine("10 hours sleeping");
        }
    }

    //Tennis Player
    public class TennisPlayer : AthleteTemplate
    {

        public override void Practice()
        {
            Console.WriteLine("4 hours practice");
        }

        public override void Sleep()
        {
            Console.WriteLine("8 hours sleeping");
        }
    }


}
