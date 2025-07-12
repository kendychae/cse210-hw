using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");
        Console.WriteLine();

        // Create individual shapes and test them
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Yellow", 3);

        Console.WriteLine("Testing individual shapes:");
        Console.WriteLine($"Square - Color: {square.GetColor()}, Area: {square.GetArea()}");
        Console.WriteLine($"Rectangle - Color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");
        Console.WriteLine($"Circle - Color: {circle.GetColor()}, Area: {circle.GetArea():F2}");
        Console.WriteLine();

        // Create a list of shapes (polymorphism in action)
        List<Shape> shapes = new List<Shape>();

        // Add different shapes to the same list
        shapes.Add(new Square("Green", 4));
        shapes.Add(new Rectangle("Purple", 3, 8));
        shapes.Add(new Circle("Orange", 2.5));
        shapes.Add(new Square("Pink", 7));
        shapes.Add(new Circle("Black", 1.5));

        Console.WriteLine("Iterating through list of shapes (Polymorphism):");
        foreach (Shape shape in shapes)
        {
            // This line demonstrates polymorphism - the same method call
            // behaves differently depending on the actual type of object
            Console.WriteLine($"Shape: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}