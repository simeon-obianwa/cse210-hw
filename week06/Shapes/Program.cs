using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Test individual classes
        Console.WriteLine("--- Testing Individual Shapes ---");
        
        Square mySquare = new Square("Red", 5.0);
        Console.WriteLine($"Square -> Color: {mySquare.GetColor()}, Area: {mySquare.GetArea()}");

        Rectangle myRect = new Rectangle("Blue", 4.0, 7.0);
        Console.WriteLine($"Rectangle -> Color: {myRect.GetColor()}, Area: {myRect.GetArea()}");

        Circle myCircle = new Circle("Green", 3.0);
        Console.WriteLine($"Circle -> Color: {myCircle.GetColor()}, Area: {myCircle.GetArea():F2}");

        // 2. Build a List of Shapes to show Polymorphism
        Console.WriteLine("\n--- Polymorphism Demo with List<Shape> ---");
        
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Yellow", 6.0));
        shapes.Add(new Rectangle("Purple", 3.0, 8.0));
        shapes.Add(new Circle("Orange", 4.5));

        // 3. Iterate through the list and call methods polymorphically
        foreach (Shape shape in shapes)
        {
            // GetArea() automatically calls the correct overridden version
            Console.WriteLine($"Shape: {shape.GetType().Name, -10} | Color: {shape.GetColor(), -7} | Area: {shape.GetArea():F2}");
        }
    }
}