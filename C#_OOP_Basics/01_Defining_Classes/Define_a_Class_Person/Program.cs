using System;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.Name = "Pesho";
        person.Age = 20;

        Person person2 = new Person("Gosho", 18);

        var person3 = new Person("Stamat", 43);
    }
}
