using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square sq1 = new Square("Blue", 3);
        shapes.Add(sq1);

        Rectangle rect1 = new Rectangle("Purple", 2, 4);
        shapes.Add(rect1);

        Circle cir1 = new Circle("Red", 6);
        shapes.Add(cir1);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The area of the {shape.GetColor()} shape is: {shape.GetArea()}");
        }
    }
}