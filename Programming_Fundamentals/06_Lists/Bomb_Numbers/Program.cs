using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> commands = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int bombNumber = commands[0];
            int bombRange = commands[1];
            int difference = 0;

            while (numbers.Contains(bombNumber))
            {
                int bombPosition = numbers.IndexOf(bombNumber);
                if ((bombPosition - bombRange < 0 && bombPosition + bombRange > numbers.Count))
                {
                    numbers.Clear();
                }
                else if (bombPosition - bombRange < 0)
                {
                    difference = bombPosition;
                    numbers.RemoveRange(0, bombRange + 1 + difference);
                }
                else if (bombPosition + bombRange >= numbers.Count) 
                {
                    difference = numbers.Count - 1 - bombPosition;
                    numbers.RemoveRange(bombPosition - bombRange, bombRange + 1 + difference);
                }
                else
                {
                    numbers.RemoveRange(bombPosition - bombRange, bombRange * 2 + 1);
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
