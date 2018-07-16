using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            try
            {
                string[] animalInfo = input.Split();
                Animal animal = ParseAnimal(animalInfo);
                animals.Add(animal);

                string[] foodInfo = Console.ReadLine().Split();
                Food food = ParseFood(foodInfo);

                Console.WriteLine(animal.MakeSound());
                animal.TryToEatFood(food);
            }
            catch (InvalidOperationException invEx)
            {
                Console.WriteLine(invEx.Message);
            }

            input = Console.ReadLine();
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static Food ParseFood(string[] foodInfo)
    {
        string foodType = foodInfo[0];
        int quantity = int.Parse(foodInfo[1]);
        switch (foodType)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Meat":
                return new Meat(quantity);
            case "Seeds":
                return new Seeds(quantity);
            default:
                throw new InvalidOperationException("Invalid food type");
        }
    }

    private static Animal ParseAnimal(string[] animalInfo)
    {
        //•	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
        //•	Birds - "{Type} {Name} {Weight} {WingSize}";
        //•	Mice and Dogs = "{Type} {Name} {Weight} {LivingRegion}";

        switch (animalInfo[0])
            {
                case "Cat":
                    return new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                case "Tiger":
                    return new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                case "Owl":
                    return new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                case "Hen":
                    return new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                case "Dog":
                    return new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                case "Mouse":
                    return new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                default:
                    throw new InvalidOperationException("Invalid animal!");
        }
    }
}
