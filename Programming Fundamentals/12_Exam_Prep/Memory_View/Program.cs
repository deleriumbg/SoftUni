using System;
using System.Linq;
using System.Text;

namespace Memory_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string entireText = string.Empty;
            while (input != "Visual Studio crash")
            {
                entireText += input + " ";
                input = Console.ReadLine();
            }

            int[] numbers = entireText.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int currentIndex = 0; currentIndex < numbers.Length - 5; currentIndex++)
            {
                if (numbers[currentIndex] == 32656 && numbers[currentIndex + 1] == 19759 && numbers[currentIndex + 2] == 32763
                    && numbers[currentIndex + 3] == 0 && numbers[currentIndex + 5] == 0)
                {
                    var stringStartIndex = currentIndex;
                    var stringLength = numbers[stringStartIndex + 4];
                    var startOfCurrentString = stringStartIndex + 6;

                    while (startOfCurrentString < entireText.Length - 6 && stringLength > 0)
                    {
                        Console.Write((char)numbers[startOfCurrentString]);
                        startOfCurrentString++;
                        stringLength--;
                    }
                    Console.WriteLine();
                    currentIndex += stringLength;
                }
            }
        }
    }
}