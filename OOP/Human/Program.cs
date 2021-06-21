using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human("Neo");
            Human h2 = new Human("Agent");
            Console.WriteLine(h1.Attack(h2));
        }
    }
}
