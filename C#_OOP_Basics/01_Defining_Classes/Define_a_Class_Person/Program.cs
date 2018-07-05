using System;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person
        {
            Name = "Pesho",
            Age = 20
        };

        Person person2 = new Person("Gosho", 18);

        var person3 = new Person("Stamat", 43);
    }
}
