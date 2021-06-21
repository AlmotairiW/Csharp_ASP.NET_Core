using System;

namespace WizardNinjaSamurai
{
    class Wizard : Human
    {
        public Wizard (string name) : base (name) {
            Intelligence = 25;
            health = 50;
        }

        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.Health -= dmg;
            this.health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.Health;
        }

        public int Heal(Human target)
        {
            target.Health += (10 * Intelligence);
            Console.WriteLine($"{Name} has healed {target.Name}");
            return target.Health;
        }

    }
}