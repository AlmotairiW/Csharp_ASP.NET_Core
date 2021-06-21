using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull"
        public bool IsFull 
        {
            get {
                return calorieIntake > 1200;
            }
        }

        // build out the Eat method
        public void Eat(Food item)
        {
            if(!this.IsFull)
            {
                this.calorieIntake += item.Calories;
                FoodHistory.Add(item);
                string sweet ="", spicy = "";
                if(item.IsSpicy)
                    spicy = "spicy";
                if (item.IsSweet)
                    sweet = "sweet";
                Console.WriteLine($"{item.Name} is {spicy} {sweet}");
            }
            else
                Console.WriteLine("This Ninja is full and can not eat anymore!");
        }
    }


}