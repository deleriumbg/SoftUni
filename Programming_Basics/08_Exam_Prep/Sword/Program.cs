using System;

namespace Sword
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftRight = n - 1;
            int width = leftRight * 2 + 3;
            Console.WriteLine(new string('#', leftRight) + '/' + '^' + '\\' + new string('#', leftRight));
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('#', leftRight - 1 - i) + '.' + new string(' ', 3 + i * 2) + '.' + new string('#', leftRight - 1 - i));
            }
            int whiteSpace = n / 2;
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'S'+ new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'O' + new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'F' + new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'T' + new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            if (n == 4)
            {
                Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace * 2 + 1) + '|' + new string('#', (n - 1) / 2));
            }
            for (int i = 0; i < n - 4; i++)
            {
                Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace * 2 + 1) + '|' + new string('#', (n - 1) / 2));
            }
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'U' + new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'N' + new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            Console.WriteLine(new string('#', (n - 1) / 2) + '|' + new string(' ', whiteSpace) + 'I' + new string(' ', whiteSpace) + '|' + new string('#', (n - 1) / 2));
            Console.WriteLine('@' + new string('=', width - 2) + '@');
            int bottomLeftRight = (n + 3) / 2;
            int bottomSpaces = width - (2 * bottomLeftRight + 2);
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('#', bottomLeftRight) + '|' + new string(' ', bottomSpaces) + '|' + new string('#', bottomLeftRight));
            }
            Console.WriteLine(new string('#', bottomLeftRight) + '\\' + new string('.', bottomSpaces) + '/' + new string('#', bottomLeftRight));
        }
    }
}
