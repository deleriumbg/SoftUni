using System;

public class Square
{
    public int Side { get; set; }

    public Square(int side)
    {
        Side = side;
    }

    public void Draw()
    {
        for (int i = 0; i < this.Side; i++)
        {
            Console.Write("|");
            if (i == 0 || i == this.Side - 1)
            {
                Console.Write($"{new string('-', this.Side)}");
            }
            else
            {
                Console.Write($"{new string(' ', this.Side)}");
            }
            Console.WriteLine("|");
        }
    }
}
