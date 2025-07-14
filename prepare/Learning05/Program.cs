// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Shapes
//         //Console.WriteLine("Hello Learning05 World!");

//     }
// }


//Polymorphism = Many forms for one function name
using System.Drawing;

public abstract class Shape
{
    //private string _color;
    public Shape(string color)
    {
        string Color = color;
    }

    public string Color(get; set;)

    public abstract double GetArea();
}


public class Square : Shape
{
    public double Side { get; set; }
    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double GetArea()
    {
        double area = Side * Side;
        return area;
        //return Side * Side;
    }
}


public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public Rectangle(string color, double side) : base(color)
    {
        Length = side;
    }

    public override double GetArea()
    {
        double area = Length * Width;
        return area;
        //return Length * Width;
    }
}

public class Circle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public Circle(string color, double side) : base(color)
    {
        Length = side;
    }

    public override double GetArea()
    {
        double area = Length * Width;
        return area;
        //return Length * Width;
    }
}
