using System;

namespace IronNinja
{
    class Drink : IConsumable
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSweet { get; set; }
        
        // Add a constructor method
        public Drink (string name, int calories, bool spicy)
        {
            this.Name = name;
            this.Calories = calories;
            this.IsSpicy = spicy;
            this. IsSweet = true;
        }
        // Implement a GetInfo Method
        public string GetInfo()
        {
            return $"{Name} (Drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
        }
        
    }


}