using System;

namespace Word_in_Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string plural = "";

            if (word.EndsWith("y"))
            {
                plural = word.Remove(word.Length - 1);
                Console.WriteLine(plural + "ies");
            }
            else if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("sh") || word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z"))
            {
                Console.WriteLine(word + "es");
            }
            else
            {
                Console.WriteLine(word + "s");
            }
        }
    }
}
