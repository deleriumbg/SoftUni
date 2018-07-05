using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> googleDatabase = new List<Person>();
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] personInfo = input.Split();
            string personName = personInfo[0];
            switch (personInfo[1])
            {
                case "company":
                    Company company = new Company(personInfo[2], personInfo[3], double.Parse(personInfo[4]));
                    if (googleDatabase.All(x => x.Name != personName))
                    {
                        Person person = new Person(personName, company);
                        googleDatabase.Add(person);
                    }
                    else
                    {
                        Person existingPerson = googleDatabase.First(x => x.Name == personName);
                        existingPerson.Company = company;
                    }
                    break;
                case "car":
                    Car car = new Car(personInfo[2], double.Parse(personInfo[3]));
                    if (googleDatabase.All(x => x.Name != personName))
                    {
                        Person person = new Person(personName, car);
                        googleDatabase.Add(person);
                    }
                    else
                    {
                        Person existingPerson = googleDatabase.First(x => x.Name == personName);
                        existingPerson.Car = car;
                    }
                    break;
                case "parents":
                    Parent parent = new Parent(personInfo[2], personInfo[3]);
                    if (googleDatabase.All(x => x.Name != personName))
                    {
                        Person person = new Person(personName, new List<Parent>());
                        person.Parents.Add(parent);
                        googleDatabase.Add(person);
                    }
                    else
                    {
                        Person existingPerson = googleDatabase.First(x => x.Name == personName);
                        if (existingPerson.Parents == null)
                        {
                            existingPerson.Parents = new List<Parent>();
                        }
                        existingPerson.Parents.Add(parent);
                    }
                    break;
                case "children":
                    Child child = new Child(personInfo[2], personInfo[3]);
                    if (googleDatabase.All(x => x.Name != personName))
                    {
                        Person person = new Person(personName, new List<Child>());
                        person.Children.Add(child);
                        googleDatabase.Add(person);
                    }
                    else
                    {
                        Person existingPerson = googleDatabase.First(x => x.Name == personName);
                        if (existingPerson.Children == null)
                        {
                            existingPerson.Children = new List<Child>();
                        }
                        existingPerson.Children.Add(child);
                    }
                    break;
                case "pokemon":
                    Pokemon pokemon = new Pokemon(personInfo[2], personInfo[3]);
                    if (googleDatabase.All(x => x.Name != personName))
                    {
                        Person person = new Person(personName, new List<Pokemon>());
                        person.Pokemons.Add(pokemon);
                        googleDatabase.Add(person);
                    }
                    else
                    {
                        Person existingPerson = googleDatabase.First(x => x.Name == personName);
                        if (existingPerson.Pokemons == null)
                        {
                            existingPerson.Pokemons = new List<Pokemon>();
                        }
                        existingPerson.Pokemons.Add(pokemon);
                    }
                    break;
            }

            input = Console.ReadLine();
        }

        string personQuery = Console.ReadLine();
        Person personResult = googleDatabase.First(x => x.Name == personQuery);
        Console.WriteLine(personResult.ToString());
    }
}
