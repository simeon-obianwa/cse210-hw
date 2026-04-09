public class Square : Shape
{
    private double _side;

    // Constructor calls base constructor for color, then sets side
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override GetArea to compute square area
    public override double GetArea()
    {
        return _side * _side;
    }
}