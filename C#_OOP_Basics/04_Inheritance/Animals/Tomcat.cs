using System;

public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
        this.Gender = "Male";
    }

    public override void ProduceSound()
    {
        Console.WriteLine("MEOW");
    }
}
