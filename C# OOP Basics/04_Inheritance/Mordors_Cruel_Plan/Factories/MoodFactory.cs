namespace Mordors_Cruel_Plan.Factories
{
    using System;
    using Moods;

    class MoodFactory
    {
        public Mood CreateMood(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "angry":
                    return new Angry();
                case "happy":
                    return new Happy();
                case "javascript":
                    return new JavaScript();
                case "sad":
                    return new Sad();
                default:
                    throw new ArgumentException("Invalid mood type");
            }
        }
    }
}
