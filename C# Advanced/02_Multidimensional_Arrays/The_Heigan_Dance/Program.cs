using System;

namespace The_Heigan_Dance
{
    class Program
    {
        private static int playerRow = 7;
        private static int playerCol = 7;
        private static int playerHealth = 18500;
        private static double heiganHealth = 3_000_000;
        private static double playerDamage;
        private static bool hasCloud;
        private static string causeOfDeath;

        private const int cloudDamage = 3500;
        private const int eruptionDamage = 6000;

        static void Main(string[] args)
        {
            playerDamage = double.Parse(Console.ReadLine());

            while (true)
            {
                if (playerHealth > 0)
                {
                    heiganHealth -= playerDamage;
                }

                if (hasCloud)
                {
                    playerHealth -= cloudDamage;
                    hasCloud = false;
                }

                if (playerHealth <= 0 || heiganHealth <= 0)
                {
                    break;
                }

                string[] input = Console.ReadLine().Split();
                string spellName = input[0];
                int targetRow = int.Parse(input[1]);
                int targetCol = int.Parse(input[2]);

                if (IsInAreaOfEffect(playerRow, playerCol, targetRow, targetCol))
                {
                    bool canMoveUp = !IsInAreaOfEffect(playerRow - 1, playerCol, targetRow, targetCol) && IsInside(playerRow - 1);
                    bool canMoveRight = !IsInAreaOfEffect(playerRow, playerCol + 1, targetRow, targetCol) && IsInside(playerCol + 1);
                    bool canMoveDown = !IsInAreaOfEffect(playerRow + 1, playerCol, targetRow, targetCol) && IsInside(playerRow + 1);
                    bool canMoveLeft = !IsInAreaOfEffect(playerRow, playerCol - 1, targetRow, targetCol) && IsInside(playerCol - 1);

                    if (canMoveUp)
                    {
                        playerRow--;
                        continue;
                    }

                    if (canMoveRight)
                    {
                        playerCol++;
                        continue;
                    }

                    if (canMoveDown)
                    {
                        playerRow++;
                        continue;
                    }

                    if (canMoveLeft)
                    {
                        playerCol--;
                        continue;
                    }

                    switch (spellName)
                    {
                        case "Cloud":
                            playerHealth -= cloudDamage;
                            hasCloud = true;
                            causeOfDeath = "Plague Cloud";
                            break;
                        case "Eruption":
                            playerHealth -= eruptionDamage;
                            causeOfDeath = "Eruption";
                            break;
                    }
                }
            }

            Console.WriteLine(heiganHealth <= 0 ? "Heigan: Defeated!" : $"Heigan: {heiganHealth:f2}");
            Console.WriteLine(playerHealth <= 0 ? $"Player: Killed by {causeOfDeath}" : $"Player: {playerHealth}");
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool IsInside(int rowColIndex)
        {
            return rowColIndex >= 0 && rowColIndex < 15;
        }

        private static bool IsInAreaOfEffect(int targetPlayerRow, int targetPlayerCol, int row, int col)
        {
            return targetPlayerRow >= row - 1 && targetPlayerRow <= row + 1 && 
                   targetPlayerCol >= col - 1 && targetPlayerCol <= col + 1;
        }
    }
}
