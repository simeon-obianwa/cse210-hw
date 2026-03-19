using System;

public class Fraction
{
    // Private attributes - Encapsulation
    private int _numerator;
    private int _denominator;

    // Constructors
    // Constructor with no parameters at 1/1
    public Fraction() : this(1, 1)
    {
    }

    // Constructor with one parameter (top), bottom at 1
    public Fraction(int top) : this(top, 1)
    {
    }

    // Constructor with two parameters at top and bottom
    public Fraction(int top, int bottom)
    {
        Numerator = top;
        Denominator = bottom;
    }

    // Getters and Setters, implemented as properties
    // Public properties to allow controlled access to private fields.
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Denominator
    {
        get { return _denominator; }
        set
        {
            // Apply Optimization to prevent division by zero
            if (value == 0)
            {
                Console.WriteLine("Error: Denominator cannot be zero. Setting to 1.");
                _denominator = 1;
            }
            else
            {
                _denominator = value;
            }
        }
    }

    // Methods to return representations
    // Returns the fraction in the form "3/4"
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Returns the decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        // Cast to double to ensure floating-point division
        return (double)_numerator / _denominator;
    }
}