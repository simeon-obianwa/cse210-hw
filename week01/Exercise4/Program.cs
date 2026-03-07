using System;
using System.Collections.Generic;

namespace ListNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int number = -1;

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            Console.WriteLine();

            // Loop to get input until 0 is entered
            while (number != 0)
            {
                Console.Write("Enter number: ");
                string input = Console.ReadLine();
                number = int.Parse(input);

                // Do not add 0 to the list
                if (number != 0)
                {
                    numbers.Add(number);
                }
            }

            // Compute the sum
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            // Compute the average
            double average = 0;
            if (numbers.Count > 0)
            {
                average = (double)sum / numbers.Count;
            }

            // Find the maximum number
            int max = int.MinValue;
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            // Find the smallest positive number
            int smallestPositive = int.MaxValue;
            foreach (int num in numbers)
            {
                if (num > 0 && num < smallestPositive)
                {
                    smallestPositive = num;
                }
            }

            // Display Core Results
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Display Stretch Results
            if (smallestPositive != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Sort the list
            numbers.Sort();

            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}