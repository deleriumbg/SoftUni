using System;

class Program
{
    static void Main(string[] args)
    {
        Person pesho = new Person();
        Console.WriteLine(pesho.Name + " " + pesho.Age);
        Person gosho = new Person(18);
        Console.WriteLine(gosho.Name + " " + gosho.Age);
        Person stamat = new Person("Stamat", 43);
        Console.WriteLine(stamat.Name + " " + stamat.Age);
    }
}
