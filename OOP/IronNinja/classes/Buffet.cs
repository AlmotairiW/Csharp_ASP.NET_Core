using System;
using System.Collections.Generic;

namespace IronNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Chicken Tikka", 100, true, false),
                new Food("Chicken Tikka masala", 150, true, false),
                new Food("Sushi", 200, false, true),
                new Food("Ice Cream", 700, false, true),
                new Food("cheesecake", 500, false, true),
                new Drink("Soda", 500, false),
                new Drink("Code Red", 600, false),
                new Drink("Beer", 400, false),
                new Drink("Smoothie", 800, false),
            };
        }

        public IConsumable Serve()
        {
            Random rand = new Random();
            int randFood = rand.Next(Menu.Count);

            return Menu[randFood];
        }
    }


}