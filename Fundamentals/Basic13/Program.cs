using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrintNumbers();
            // PrintOdds();
            // PrintSum();

            // int[] nums = { 3, -3, 100 };
            // Console.WriteLine("Max Number: " + FindMax(nums));
            // GetAverage(nums);

            // int[] odds = OddArray();
            // for (int i = 0; i < odds.Length; i++)
            // {
            //     Console.WriteLine(odds[i]);
            // }

            // int[] array = { 1, 3, 5, 7 };
            // Console.WriteLine(GreaterThanY(array, 3));

            // int[] arr = { 1, 5, 10, -10 };
            // SquareArrayValues(arr);

            // int[] arr = { 1, 5, 10, -2 };
            // EliminateNegatives(arr);

            // int[] mma = { 1, 5, 10, -2 };
            // MinMaxAverage(mma);

            // int[] shift = { 1, 5, 10, 7, -2 };
            // ShiftValues(shift); 

            int[] ints = { -1, -3, 2 };
            object[] toStr = NumToString(ints);
            foreach (var item in toStr)
            {
                Console.Write($"{item}, ");
            }

        }

        public static void PrintNumbers()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds()
        {
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine(i);
            }
        }

        public static void PrintSum()
        {
            // Print all of the numbers from 0 to 255, 
            // but this time, also print the sum as you go. 
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine($"New Number: {i} Sum: {sum}");
            }
        }

        public static int FindMax(int[] numbers)
        {
            // Write a function that takes an integer array and prints and returns the maximum value in the array. 
            // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
            // or even a mix of positive numbers, negative numbers and zero.
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
            }

            return max;
        }

        public static void GetAverage(int[] numbers)
        {
            // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
            // For example, with an array [2, 10, 3], your program should write 5 to the console.
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            float avg = (float)sum / numbers.Length;
            Console.WriteLine("Array Avg: " + avg);
        }
        public static int[] OddArray()
        {
            // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
            // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
            List<int> odds = new List<int>();
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 != 0)
                    odds.Add(i);
            }
            return odds.ToArray();
        }

        public static int GreaterThanY(int[] numbers, int y)
        {
            // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
            // That are greater than the "y" value. 
            // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
            // (since there are two values in the array that are greater than 3).
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                    count++;
            }

            return count;
        }
        public static void SquareArrayValues(int[] numbers)
        {
            // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
            // For example, [1,5,10,-10] should become [1,25,100,100]
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Value: " + numbers[i]);
                numbers[i] = numbers[i] * numbers[i];
                Console.WriteLine("Value Squared: " + numbers[i]);
            }
        }

        public static void EliminateNegatives(int[] numbers)
        {
            // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
            // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    numbers[i] = 0;
            }
            Console.Write("New Array: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + ", ");
            }
        }

        public static void MinMaxAverage(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
            // the minimum value in the array, and the average of the values in the array.
            int max = numbers[0], min = numbers[0], sum = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                sum += numbers[i];
                if (numbers[i] > max)
                    max = numbers[i];

                if (numbers[i] < min)
                    min = numbers[i];
            }
            float avg = (float)sum / numbers.Length;
            Console.WriteLine($"Max: {max}, Min: {min}, Avg: {avg}");
        }

        public static void ShiftValues(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, 7, -2], 
            // Write a function that shifts each number by one to the front and adds '0' to the end. 
            // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
            // it should become [5, 10, 7, -2, 0].

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[i + 1];
            }
            numbers[numbers.Length - 1] = 0;

            Console.Write("New Array: ");
            foreach(var item in numbers)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

        }

        public static object[] NumToString(int[] numbers)
        {
            // Write a function that takes an integer array and returns an object array 
            // that replaces any negative number with the string 'Dojo'.
            // For example, if array "numbers" is initially [-1, -3, 2] 
            // your function should return an array with values ['Dojo', 'Dojo', 2].
            object[] toReturn = new object[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    toReturn[i] = "Dojo";
                else
                    toReturn[i] = numbers[i];
            }
            return toReturn;
        }
    }
}
