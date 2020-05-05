using System;

namespace External_Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());
            int poorCounter = 0;
            int satisfactoryCounter = 0;
            int goodCounter = 0;
            int veryGoodCounter = 0;
            int excellentCounter = 0;

            for (int i = 0; i < students; i++)
            {
                double points = double.Parse(Console.ReadLine());
                if (points >= 0 && points <= 22.5)
                {
                    poorCounter++;
                }
                else if (points > 22.5 && points <= 40.5)
                {
                    satisfactoryCounter++;
                }
                else if (points > 40.5 && points <= 58.5)
                {
                    goodCounter++;
                }
                else if (points > 58.5 && points <= 76.5)
                {
                    veryGoodCounter++;
                }
                else
                {
                    excellentCounter++;
                }
            }
            Console.WriteLine($"{(poorCounter / students) * 100:f2}% poor marks");
            Console.WriteLine($"{(satisfactoryCounter / students) * 100:f2}% satisfactory marks");
            Console.WriteLine($"{(goodCounter / students) * 100:f2}% good marks");
            Console.WriteLine($"{(veryGoodCounter / students) * 100:f2}% very good marks");
            Console.WriteLine($"{(excellentCounter / students) * 100:f2}% excellent marks");
        }
    }
}
