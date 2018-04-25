using System;
using System.Linq;

namespace Rectangle_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle R1 = ReadRectangle();
            Rectangle R2 = ReadRectangle();
            Console.WriteLine(R1.IsInside(R2) ? "Inside" :"Not inside");

        }

        public static Rectangle ReadRectangle()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Rectangle rectangle = new Rectangle();
            {
                rectangle.Left = input[0];
                rectangle.Top = input[1];
                rectangle.Width = input[2];
                rectangle.Height = input[3];
            }
            return rectangle;
        }
    }

    class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right { get { return Left + Width; } }
        public int Bottom { get { return Top + Height; } }

        public bool IsInside(Rectangle r)
        {
            return (r.Left <= Left) && (r.Right >= Right) && (r.Top <= Top) && (r.Bottom >= Bottom);
        }
    }
}
