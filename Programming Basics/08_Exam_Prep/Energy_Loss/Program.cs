using System;

namespace Energy_Loss
{
    class Program
    {
        static void Main(string[] args)
        {
            int trainingDays = int.Parse(Console.ReadLine());
            int dancersCount = int.Parse(Console.ReadLine());
            double totalWastedEnergy = 0;
            for (int i = 1; i <= trainingDays; i++)
            {
                int hours = int.Parse(Console.ReadLine());
                if (hours % 2 == 0 && i % 2 == 0)
                {
                    totalWastedEnergy += dancersCount * 68;
                }
                else if (hours % 2 == 0 && i % 2 != 0)
                {
                    totalWastedEnergy += dancersCount * 49;
                }
                else if (hours % 2 != 0 && i % 2 == 0)
                {
                    totalWastedEnergy += dancersCount * 65;
                }
                else if (hours % 2 != 0 && i % 2 != 0)
                {
                    totalWastedEnergy += dancersCount * 30;
                }
            }
            double totalEnergy = 100 * trainingDays * dancersCount;
            double energyLeft = totalEnergy - totalWastedEnergy;
            double energyPerDancer = energyLeft / dancersCount / trainingDays;
            if (energyPerDancer <= 50)
            {
                Console.WriteLine($"They are wasted! Energy left: {energyPerDancer:f2}");
            }
            else
            {
                Console.WriteLine($"They feel good! Energy left: {energyPerDancer:f2}");
            }
        }
    }
}
