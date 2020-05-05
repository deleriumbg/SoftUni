using System;
using System.Collections.Generic;

public class StudentSystem
{
    public Dictionary<string, Student> Repo { get; }
    public StudentSystem()
    {
        Repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string input)
    {
        string[] args = input.Split();

        switch (args[0])
        {
            case "Create":
                {
                    Create(args[1], args[2], args[3]);
                    break;
                }
            case "Show":
                {
                    Show(args[1]);
                    break;
                }
        }
    }

    private void Show(string name)
    {
        if (Repo.ContainsKey(name))
        {
            var student = Repo[name];
            Console.WriteLine(student);
        }
    }

    private void Create(string name, string ageString, string gradeString)
    {
        var age = int.Parse(ageString);
        var grade = double.Parse(gradeString);
        if (!Repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            Repo[name] = student;
        }
    }
}
