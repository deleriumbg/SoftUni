namespace Mordors_Cruel_Plan
{
    using System;
    using Factories;
    using Foods;
    using Moods;

    class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.moodFactory = new MoodFactory();
        }

        public void Run()
        {
            int points = 0;
            string[] input = Console.ReadLine().Split();

            foreach (var type in input)
            {
                Food currentFood = foodFactory.CreateFood(type);
                points += currentFood.Happiness;
            }

            Mood mood;
            if (points < -5)
            {
                mood = moodFactory.CreateMood("angry");
            }
            else if (points >= -5 && points <= 0)
            {
                mood = moodFactory.CreateMood("sad");
            }
            else if (points >= 1 && points <= 15)
            {
                mood = moodFactory.CreateMood("happy");
            }
            else
            {
                mood = moodFactory.CreateMood("javascript");
            }

            Console.WriteLine(points);
            Console.WriteLine(mood.Type);
        }
    }
}
