using System;
using System.Collections.Generic;
using System.Linq;

namespace Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new string[] {": ", ", "}, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
            string name = input[0];
            List<string> cards = input.Skip(1).ToList();
            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();
            int sum = 0;

            while (name != "JOKER")
            {
                if (players.ContainsKey(name) == false)
                {
                    players.Add(name, cards);
                }
                else
                {
                    players[name].AddRange(cards);
                }
                input = Console.ReadLine().Split(new string[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                name = input[0];
                cards = input.Skip(1).ToList();
            }

            int multiplyer = 0;
            int value = 0;
            foreach (var player in players)
            {
                foreach (var card in player.Value)
                {
                    switch (card[card.Length - 1])
                    {
                        case 'S':
                            multiplyer = 4;
                            break;
                        case 'H':
                            multiplyer = 3;
                            break;
                        case 'D':
                            multiplyer = 2;
                            break;
                        case 'C':
                            multiplyer = 1;
                            break;
                    }

                    switch (card[0])
                    {
                        case '2':
                            value = 2;
                            break;
                        case '3':
                            value = 3;
                            break;
                        case '4':
                            value = 4;
                            break;
                        case '5':
                            value = 5;
                            break;
                        case '6':
                            value = 6;
                            break;
                        case '7':
                            value = 7;
                            break;
                        case '8':
                            value = 8;
                            break;
                        case '9':
                            value = 9;
                            break;
                        case '1':
                            value = 10;
                            break;
                        case 'J':
                            value = 11;
                            break;
                        case 'Q':
                            value = 12;
                            break;
                        case 'K':
                            value = 13;
                            break;
                        case 'A':
                            value = 14;
                            break;
                    }
                    sum += value * multiplyer;
                }
                Console.WriteLine($"{player.Key}: {sum}");
                sum = 0;
            }
        }
    }
}
