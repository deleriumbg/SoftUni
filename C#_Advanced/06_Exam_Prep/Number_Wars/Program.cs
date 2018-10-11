using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_Wars
{
    class Program
    {
        private const int MaxTurns = 1_000_000;

        static void Main(string[] args)
        {
            Queue<string> firstPlayerCards = new Queue<string>(Console.ReadLine().Split());
            Queue<string> secondPlayerCards = new Queue<string>(Console.ReadLine().Split());

            int turnCounter = 0;
            bool winnerFound = false;
            
            while (turnCounter < MaxTurns && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && !winnerFound)
            {
                turnCounter++;
                string firstCard = firstPlayerCards.Dequeue();
                string secondCard = secondPlayerCards.Dequeue();
                
                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstPlayerCards.Enqueue(firstCard);
                    firstPlayerCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }
                else
                {
                    List<string> currentHand = new List<string>{ firstCard, secondCard };

                    while (!winnerFound)
                    {
                        if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                string currentFirst = firstPlayerCards.Dequeue();
                                string currentSecond = secondPlayerCards.Dequeue();
                                firstSum += GetChar(currentFirst);
                                secondSum += GetChar(currentSecond);
                                currentHand.Add(currentFirst);
                                currentHand.Add(currentSecond);
                            }

                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(firstPlayerCards, currentHand);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCardsToWinner(secondPlayerCards, currentHand);
                                break;
                            }
                        }
                        else
                        {
                            winnerFound = true;
                        }
                    }
                }
            }

            string result;

            if (firstPlayerCards.Count == secondPlayerCards.Count)
            {
                result = "Draw";
            }
            else if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turnCounter} turns");
        }

        private static void AddCardsToWinner(Queue<string> winnerPlayerCards, IEnumerable<string> currentHand)
        {
            foreach (var card in currentHand.OrderByDescending(GetNumber).ThenByDescending(GetChar))
            {
                winnerPlayerCards.Enqueue(card);
            }
        }

        private static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        private static int GetChar(string card)
        {
            //a -> 1, b -> 2, c -> 3 etc. 
            return card[card.Length - 1] - 96;
        }
    }
}
