using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Chicken Tikka", 100, true, false),
                new Food("Chicken Tikka masala", 150, true, false),
                new Food("Sushi", 200, false, true),
                new Food("Sashimi", 180, false, true),
                new Food("Unagi", 200, true, false),
                new Food("Ice Cream", 700, false, true),
                new Food("cheesecake", 500, false, true)
            };
        }

        public Food Serve()
        {
            Random rand = new Random();
            int randFood = rand.Next(Menu.Count);

            return Menu[randFood];
        }
    }


}