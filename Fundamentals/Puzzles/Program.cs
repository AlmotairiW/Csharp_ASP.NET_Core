using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // int [] randArr = RandomArray();
            // foreach(int item in randArr)
            // Console.Write(item + ",");
            // Console.WriteLine(TossCoin());
            // Console.WriteLine(TossMultipleCoins(4));

            List<string> longerThan5 = Names();
            Console.WriteLine("-----");
            foreach(var val in longerThan5)
                Console.WriteLine(val);
        }

        public static int[] RandomArray()
        {

            Random rand = new Random();
            int[] randArr = new int[10];
            int min = 26, max = 0, sum = 0, randNum;

            for (int i = 0; i< randArr.Length; i++)
            {
                randNum = rand.Next(5,26);
                randArr[i] = randNum;
                sum+= randArr[i];

                if(randArr[i] > max)
                max = randArr[i];

                if(randArr[i] < min)
                min = randArr[i];
            }
            Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");
            return randArr;
        }

        public static string TossCoin()
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int randNum = rand.Next(0,2);
            string res;

            if(randNum == 0)
            res = "Heads";
            else
            res = "Tails";

            Console.WriteLine(res);

            return res;
        }

        public static double TossMultipleCoins(int num)
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int randNum, total = num;
            double heads = 0.0;

            while( num > 0)
            {
                randNum = rand.Next(0,2);
                if(randNum == 0)
                heads++;
                
                num--;
            }

            double res = heads/total;
            return res;
        }
        public static List<string> Names()
        {
            List<string> names= new List<string>() {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};

            var rand = new Random();
            var randomized = names.OrderBy(item => rand.Next());

            foreach (var value in randomized)
            {
                Console.WriteLine(value);
            }

            List<string> toRet = new List<string>();
            foreach( var val in names)
            {
                if(val.Length > 5)
                    toRet.Add(val);

            }

            return toRet;

        }
    }
}
