using System;

namespace Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = n + 5;
            int leftRightTop = (width - 1) / 2;
            int leftRightSecondRow = (width - 3) / 2;
            int leftRightThirdRow = (width - 5) / 2;
            Console.WriteLine(new string('_', leftRightTop) + '^' + new string('_', leftRightTop));
            Console.WriteLine(new string('_', leftRightSecondRow) + '/' + '|' + '\\' + new string('_', leftRightSecondRow));
            
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('_', leftRightThirdRow - i) + '/' + new string('.', i) + "|||" + new string('.', i) + '\\' + new string('_', leftRightThirdRow - i));
            }
            for (int i = 2; i >= 1; i--)
            {
                Console.WriteLine(new string('_', leftRightThirdRow - i) + '/' + new string('.', i) + "|||" + new string('.', i) + '\\' + new string('_', leftRightThirdRow - i));
            }
            int leftRightMid = (width - 3) / 2;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('_', leftRightMid) + "|||" +  new string('_', leftRightMid));
            }
            Console.WriteLine(new string('_', leftRightMid) + "~~~" + new string('_', leftRightMid));
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine(new string('_', leftRightMid - 1 - i) + "//" + new string('.', i) + '!' + new string('.', i) + @"\\" + new string('_', leftRightMid - 1 - i));
            }
        }
    }
}
