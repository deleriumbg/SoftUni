using System;

class Program
{
    static void Main(string[] args)
    {
        string figureType = Console.ReadLine();
        switch (figureType)
        {
            case "Square":
                int side = int.Parse(Console.ReadLine());
                Square square = new Square(side);
                square.Draw();
                break;
            case "Rectangle":
                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                Rectangle rectangle = new Rectangle(width, height);
                rectangle.Draw();
                break;
        }
    }
}
