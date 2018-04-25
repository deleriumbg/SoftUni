using System;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int total = 0;
            int red = 0;
            int orange = 0;
            int yellow = 0;
            int white = 0;
            int other = 0;
            int black = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "red":
                        total += 5;
                        red++;
                        break;
                    case "orange":
                        total += 10;
                        orange++;
                        break;
                    case "yellow":
                        total += 15;
                        yellow++;
                        break;
                    case "white":
                        total += 20;
                        white++;
                        break;
                    case "black":
                        total /= 2;
                        black++;
                        break;
                    default:
                        other++;
                        break;
                }
            }
            Console.WriteLine($"Total points: {total}\r\nPoints from red balls: {red}\r\nPoints from orange balls: {orange}\r\nPoints from yellow balls: {yellow}\r\nPoints from white balls: {white}\r\nOther colors picked: {other}\r\nDivides from black balls: {black}");
        }
    }
}
