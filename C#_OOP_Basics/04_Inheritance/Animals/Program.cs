using System;

class Program
{
    static void Main(string[] args)
    {
        string animalType = Console.ReadLine();
        while (animalType != "Beast!")
        {
            try
            {
                ParseAnimal(animalType);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            animalType = Console.ReadLine();
        }
    }

    private static void ParseAnimal(string animalType)
    {
        string[] input = Console.ReadLine().Split();
        string name = input[0];
        int age = int.Parse(input[1]);
        string gender = null;
        if (input.Length == 3)
        {
            gender = input[2];
        }
        switch (animalType)
        {
            case "Cat":
                Cat cat = new Cat(name, age, gender);
                Console.WriteLine(cat);
                cat.ProduceSound();
                break;
            case "Dog":
                Dog dog = new Dog(name, age, gender);
                Console.WriteLine(dog);
                dog.ProduceSound();
                break;
            case "Frog":
                Frog frog = new Frog(name, age, gender);
                Console.WriteLine(frog);
                frog.ProduceSound();
                break;
            case "Kitten":
                Kitten kitten = new Kitten(name, age, gender);
                Console.WriteLine(kitten);
                kitten.ProduceSound();
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(name, age, gender);
                Console.WriteLine(tomcat);
                tomcat.ProduceSound();
                break;
            default:
                throw new ArgumentException(Animal.ERROR_MESSAGE);
        }
    }
}
