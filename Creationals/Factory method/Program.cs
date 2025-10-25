using System;
interface IFigure
{
    void Draw();
}
class Circle : IFigure
{
    public void Draw()
    {
        Console.WriteLine("A circle is drawn.");
    }
}
class Square : IFigure
{
    public void Draw()
    {
        Console.WriteLine("A square is drawn.");
    }
}
class Triangle : IFigure
{
    public void Draw()
    {
        Console.WriteLine("A triangle is drawn.");
    }
}
abstract class Painting
{
    public abstract IFigure CreateFigure();
    public void ChoiceFigure()
    {
        IFigure figure = CreateFigure();
        figure.Draw();
    }
}
class CircleDraw : Painting
{
    public override IFigure CreateFigure()
    {
        return new Circle();
    }
}
class SquareDraw : Painting
{
    public override IFigure CreateFigure()
    {
        return new Square();
    }
}
class TriangleDraw : Painting
{
    public override IFigure CreateFigure()
    {
        return new Triangle();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Painting painting = null;
        Console.WriteLine("Enter the shape you want to draw (circle, square, triangle)\n");
        string shape = Console.ReadLine().ToLower();
        if (shape == "circle")
        {
            painting = new CircleDraw();
        }
        else if (shape == "square")
        {
            painting = new SquareDraw();
        }
        else if (shape == "triangle")
        {
            painting = new TriangleDraw();
        }
        else Console.WriteLine("Unknown figure.");
        painting?.ChoiceFigure();
    }
}