using System;

namespace WizardNinjaSamurai
{
    class Ninja : Human
    {
        public Ninja(string name): base(name)
        {
            Dexterity = 175;
        }


        public override int Attack(Human target)
        {
            Random rand = new Random();
            int dmg = Dexterity * 5, chance = rand.Next(100);

            if(chance < 20)
                dmg += 10;
            
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }

        public int Steal(Human target)
        {
            target.Health -= 5;
            this.Health += 5;

            return target.Health;
        }
        
    }
}