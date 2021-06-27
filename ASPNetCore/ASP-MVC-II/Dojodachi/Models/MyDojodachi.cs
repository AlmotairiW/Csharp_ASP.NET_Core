using System;
namespace Dojodachi.Models
{
    public class MyDojodachi
    {
        public int Fullness{set;get;}
        public int Happiness{set;get;}
        public int Meals{set;get;}
        public int Energy{set;get;}

        public bool EnoughMeals {
            get
            {
                return Meals > 0;
            }
        }

        public bool Alive {
            get
            {
                return Fullness > 0 && Happiness > 0;
            }
        }
        public bool Win{
            get
            {
                return Fullness >= 100 && Happiness >= 100 && Energy >= 100;
            }
        }

        public MyDojodachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }

        public string Feed()
        {
            if(EnoughMeals)
            {
                Meals -= 1;
                Random rand = new Random();
                int like = rand.Next(100);
                int extraFullness = 0;
                if(like > 25)
                {   //likes it :)
                    extraFullness = rand.Next(5,11);
                }
                Fullness += extraFullness;
                return $"You Fed your Dojodachi! Fullness + {extraFullness}, Meals: -1";
            }
            return "There are not enough Meals!";
        }

        public string Play()
        {
            Energy -= 5;
            Random rand = new Random();
            int like = rand.Next(100);
            int extraHappiness = 0;
            if(like > 25)
            {   //likes it :)
                extraHappiness = rand.Next(5,11);
            }
            Happiness += extraHappiness;
            return $"You Played with your Dojodachi! Happiness + {extraHappiness}, Energy: -5";

        }

        public string Work()
        {
            Energy -= 5;
            Random rand = new Random();
            int extraMeals = rand.Next(1,4);
            Meals += extraMeals;
            return $"You Dojodachi has been working! Meals: {extraMeals}, Energy: -5";
        }

        public string Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            return "You Dojodachi has been sleeping! Energy: +15, Fullness: -5, Happiness: -5";
        }

    }
}