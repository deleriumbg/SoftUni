using System;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        Team team = new Team("Softuni");
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                team.AddPlayer(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}
