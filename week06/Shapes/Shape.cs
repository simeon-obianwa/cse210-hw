using System;

public class Shape
{
    // Member variable for color
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Setter for color
    public void SetColor(string color)
    {
        _color = color;
    }

    // The virtual method was used and overridden by derived classes
    public virtual double GetArea()
    {
        return 0; 
    }
}