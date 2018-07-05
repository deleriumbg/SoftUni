using System;

public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void Draw()
    {
        for (int i = 0; i < this.Height; i++)
        {
            Console.Write("|");
            if (i == 0 || i == this.Height - 1)
            {
                Console.Write($"{new string('-', this.Width)}");
            }
            else
            {
                Console.Write($"{new string(' ', this.Width)}");
            }
            Console.WriteLine("|");
        }
    }
}
