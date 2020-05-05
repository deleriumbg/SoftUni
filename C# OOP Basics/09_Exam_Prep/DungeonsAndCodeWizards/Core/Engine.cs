using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private readonly DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                string[] args = inputArgs.Skip(1).ToArray();
                string output = String.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            output = this.dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            output = this.dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            output = this.dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            output = this.dungeonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            output = this.dungeonMaster.UseItemOn(args);
                            break;
                        case "GiveCharacterItem":
                            output = this.dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            output = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            output = this.dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            output = this.dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            output = this.dungeonMaster.EndTurn();
                            break;
                        case "IsGameOver":
                            this.dungeonMaster.IsGameOver();
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    output = $"Parameter Error: {ae.Message}";
                }
                catch (InvalidOperationException ioe)
                {
                    output = $"Invalid Operation: {ioe.Message}";
                }

                Console.WriteLine(output);
                if (this.dungeonMaster.IsGameOver())
                {
                    break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
