using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> lis = new List<object>();

            lis.Add(7);
            lis.Add(28);
            lis.Add(-1);
            lis.Add("chair");

            int intVals = 0;
            foreach( var item in lis)
            {
                Console.WriteLine(item);
                if(item is int)
                {
                    intVals += (int)item;
                }
            }
            Console.WriteLine("Integers Sum: " + intVals);
        }
    }
}
