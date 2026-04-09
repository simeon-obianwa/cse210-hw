using System;

public class Circle : Shape
{
    private double _radius;

    // Constructor calls base constructor for color, then sets radius
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea to compute circle area
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}