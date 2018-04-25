using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthPlayground = double.Parse(Console.ReadLine());
            double lengthPlayground = double.Parse(Console.ReadLine());
            double sandPricePerSqurM = double.Parse(Console.ReadLine());
            double woodPricePerPiece = double.Parse(Console.ReadLine());

            double playgroundArea = widthPlayground * lengthPlayground;
            double sandArea = (widthPlayground - (0.2 + 0.2)) * (lengthPlayground - (0.2 + 0.2));
            double borderArea = playgroundArea - sandArea;
            double sandQuantity = Math.Ceiling(sandArea * 20);
            double woodQuantity = Math.Ceiling(borderArea / (2.2 * 0.2));
            double sandPrice = sandPricePerSqurM * sandQuantity;
            double woodPrice = woodPricePerPiece * woodQuantity;
            Console.WriteLine($"{sandPrice + woodPrice:f2}");
        }
    }
}
