using System;

namespace WizardNinjaSamurai
{
    class Samurai : Human
    {
        public Samurai(string name) : base( name)
        {
            health = 200;
        }


        public override int Attack(Human target)
        {
            if(base.Attack(target) < 50)
                target.Health = 0;
            
            return target.Health;
        }

        public void Meditate()
        {
            health = 200;
            Console.WriteLine($"{Name} is back to full health!");
        }
        
    }
}