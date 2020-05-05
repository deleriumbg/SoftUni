using System;

namespace Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            // Made everything double, despite the condition of the task saying int. 
            // That way I eliminated a problem where I was getting result 0 when dividing two ints.
            double capacity = double.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());
            double counterA = 0;
            double counterB = 0;
            double counterV = 0;
            double counterG = 0;
            
            for (int i = 0; i < fans; i++)
            {
                string sector = Console.ReadLine();
                switch (sector)
                {
                    case "A":
                        counterA += 1;
                        break;
                    case "B":
                        counterB += 1;
                        break;
                    case "V":
                        counterV += 1;
                        break;
                    case "G":
                        counterG += 1;
                        break;
                }
            }
            double fansA = (counterA / fans) * 100;
            double fansB = (counterB / fans) * 100;
            double fansV = (counterV / fans) * 100;
            double fansG = (counterG / fans) * 100;
            double fansAll = (fans / capacity) * 100;
            Console.WriteLine($"{fansA:f2}%\r\n{fansB:f2}%\r\n{fansV:f2}%\r\n{fansG:f2}%\r\n{fansAll:f2}%");
        }
    }
}
