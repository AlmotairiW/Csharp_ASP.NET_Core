using System;

namespace Human
{
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        // add a public "getter" property to access health
        public int healthProp
        {
            get
            {
                return health;
            }
        }

        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human (string Name)
        {
            this.Name = Name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        // Add a constructor to assign custom values to all fields
        public Human (string Name, int Strength, int Intelligence, int Dexterity, int health)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Intelligence = Intelligence;
            this.Dexterity = Dexterity;
            this.health = health;
        }


        // Build Attack method
        public int Attack(Human target)
        {
            target.health -= (5 * this.Strength);
            return target.health;
        }
    }

}


