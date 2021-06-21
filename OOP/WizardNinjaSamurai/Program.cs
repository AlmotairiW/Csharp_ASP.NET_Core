using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human wiz = new Wizard("wal");
            Human sam = new Samurai("Hell");
            Console.WriteLine(sam.Attack(wiz));
            
        }
    }
}
