using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers =  {0,1,2,3,4,5,6,7,8,9};
            string[] names = {"Tim", "Martin", "Nikki","Sara"};
            bool[] bools = {true, false, true, false, true, false, true, false, true, false};

            List<string> flavors = new List<string>();
            flavors.Add("Almond Chocolate Coconut");
            flavors.Add("Banana");
            flavors.Add("Black Cherry");
            flavors.Add("Caramel Cheesecake");
            flavors.Add("Vanilla");

            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors[2]);
            Console.WriteLine(flavors.Count);

            Dictionary<string,string> names_flavors = new Dictionary<string,string>();

            Random rand = new Random();
            for(int i = 0; i < names.Length; i++)
            {
                int randNum = rand.Next(0, 4);
                names_flavors.Add(names[i], flavors[randNum]);
            }

            foreach( var entry in names_flavors)
            {
                Console.WriteLine(entry.Key + " Likes: " + entry.Value);
            }
        }
    }
}
