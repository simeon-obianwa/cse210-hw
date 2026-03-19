using System;

namespace FractionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Encapsulation Activity: Fraction Class ===\n");

            // Verify Constructors
            Console.WriteLine("--- Testing Constructors ---");
            
            // Verify no parameters (1/1)
            Fraction frac1 = new Fraction();
            Console.WriteLine($"Constructor 1 (No args): {frac1.GetFractionString()}");

            // Verify One parameter (6/1)
            Fraction frac2 = new Fraction(6);
            Console.WriteLine($"Constructor 2 (One arg): {frac2.GetFractionString()}");

            // Verify Two parameters (6/7)
            Fraction frac3 = new Fraction(6, 7);
            Console.WriteLine($"Constructor 3 (Two args): {frac3.GetFractionString()}");

            Console.WriteLine();

            // Verify Getters and Setters
            Console.WriteLine("--- Testing Getters and Setters ---");
            
            // New fraction to modify
            Fraction frac4 = new Fraction(3, 4);
            Console.WriteLine($"Initial Value: {frac4.GetFractionString()}");

            // Applying Setters to change values
            frac4.Numerator = 5;
            frac4.Denominator = 8;

            // Applying Getters to retrieve and display new values
            Console.WriteLine($"Updated via Setters: {frac4.GetFractionString()}");
            
            // Denominator validation by setting to 0
            Console.WriteLine("Attempting to set denominator to 0...");
            frac4.Denominator = 0; 
            Console.WriteLine($"Result after invalid set: {frac4.GetFractionString()}");

            Console.WriteLine();

            // Verify Representation Methods
            Console.WriteLine("--- Testing Representation Methods ---");

            Fraction frac5 = new Fraction(3, 4);
            Console.WriteLine($"Fraction: {frac5.GetFractionString()}");
            Console.WriteLine($"Decimal : {frac5.GetDecimalValue()}");

            Fraction frac6 = new Fraction(1, 3);
            Console.WriteLine($"Fraction: {frac6.GetFractionString()}");
            Console.WriteLine($"Decimal : {frac6.GetDecimalValue()}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}