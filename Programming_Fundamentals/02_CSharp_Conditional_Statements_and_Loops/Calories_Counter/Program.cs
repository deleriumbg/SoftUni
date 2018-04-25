using System;

namespace Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int ingredientsCount = int.Parse(Console.ReadLine());
            int calories = 0;
            int totalCalories = 0;

            for (int i = 1; i <= ingredientsCount; i++)
            {
                string ingredient = Console.ReadLine().ToLower();

                switch (ingredient)
                {
                    case "cheese":
                        calories = 500;
                        totalCalories += calories;
                        break;
                    case "tomato sauce":
                        calories = 150;
                        totalCalories += calories;
                        break;
                    case "salami":
                        calories = 600;
                        totalCalories += calories;
                        break;
                    case "pepper":
                        calories = 50;
                        totalCalories += calories;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
