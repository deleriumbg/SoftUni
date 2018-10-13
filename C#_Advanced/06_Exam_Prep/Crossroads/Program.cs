using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int passedCars = 0;

            Queue<string> cars = new Queue<string>();
            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                if (commandInput != "green")
                {
                    cars.Enqueue(commandInput);
                }
                else
                {
                    int currentGreenDuration = greenLightDuration;
                    while (currentGreenDuration > 0 && cars.Count > 0)
                    {
                        string currentCar = cars.Dequeue();
                        if (currentCar.Length <= currentGreenDuration)
                        {
                            passedCars++;
                            currentGreenDuration -= currentCar.Length;
                        }
                        else if (currentCar.Length > currentGreenDuration && currentCar.Length <= currentGreenDuration + freeWindow)
                        {
                            passedCars++;
                            currentGreenDuration = 0;
                        }
                        else
                        {
                            int crashIndex = currentCar.Length - Math.Abs(freeWindow + currentGreenDuration);
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[crashIndex]}.");
                            return;
                        }
                    }

                }
                commandInput = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.\r\n{passedCars} total cars passed the crossroads.");
        }
    }
}
