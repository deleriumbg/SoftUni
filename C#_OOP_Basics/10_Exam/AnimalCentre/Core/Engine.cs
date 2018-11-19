using System;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private readonly AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                
                string[] args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                string output = String.Empty;

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            output = this.animalCentre.RegisterAnimal(args[1], args[2], int.Parse(args[3]),
                                int.Parse(args[4]),
                                int.Parse(args[5]));
                            break;
                        case "Chip":
                            output = this.animalCentre.Chip(args[1], int.Parse(args[2]));
                            break;
                        case "Vaccinate":
                            output = this.animalCentre.Vaccinate(args[1], int.Parse(args[2]));
                            break;
                        case "Fitness":
                            output = this.animalCentre.Fitness(args[1], int.Parse(args[2]));
                            break;
                        case "Play":
                            output = this.animalCentre.Play(args[1], int.Parse(args[2]));
                            break;
                        case "DentalCare":
                            output = this.animalCentre.DentalCare(args[1], int.Parse(args[2]));
                            break;
                        case "NailTrim":
                            output = this.animalCentre.NailTrim(args[1], int.Parse(args[2]));
                            break;
                        case "Adopt":
                            output = this.animalCentre.Adopt(args[1], args[2]);
                            break;
                        case "History":
                            output = this.animalCentre.History(args[1]);
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    output = $"InvalidOperationException: {ioe.Message}";
                }
                catch (ArgumentException ae)
                {
                    output = $"ArgumentException: {ae.Message}";
                }

                Console.WriteLine(output);
                input = Console.ReadLine();
            }

            this.animalCentre.End();
        }
    }
}
