public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor calls base constructor for color, then sets sides
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override GetArea to compute rectangle area
    public override double GetArea()
    {
        return _length * _width;
    }
}