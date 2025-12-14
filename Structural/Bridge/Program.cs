using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

interface IColor
{
    string GetColor();
}

class Red : IColor
{
    public string GetColor() => "Red";
}

class Blue : IColor
{
    public string GetColor() => "Blue";
}

class Green : IColor
{
    public string GetColor() => "Green";
}

abstract class Shape
{
    protected IColor color;
    
    public Shape(IColor color)
    {
        this.color = color;
    }
    
    public abstract void Draw();
}

class Circle : Shape
{
    public Circle(IColor color) : base(color) { }
    
    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.GetColor()} circle");
    }
}

class Square : Shape
{
    public Square(IColor color) : base(color) { }
    
    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.GetColor()} square");
    }
}

class Triangle : Shape
{
    public Triangle(IColor color) : base(color) { }
    
    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.GetColor()} triangle");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape RedTriangle = new Triangle(new Red());
        Shape GreenTriangle = new Triangle(new Green());
        Shape BlueTriangle = new Triangle(new Blue());
        Shape BlueSquare = new Square(new Blue());
        Shape GreenCircle = new Circle(new Green());
        
        RedTriangle.Draw();
        GreenTriangle.Draw();
        BlueTriangle.Draw();
        BlueSquare.Draw(); 
        GreenCircle.Draw();
    }
}
