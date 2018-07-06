public class Student
{
    public double Grade { get; set; }

    public int Age { get; set; }

    public string Name { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public override string ToString()
    {
        string comment = GetGradeComment();
        string view = $"{Name} is {Age} years old. {comment}";
        return view;
    }

    private string GetGradeComment()
    {
        if (Grade >= 5.00)
        {
            return "Excellent student.";
        }
        if (Grade < 5.00 && Grade >= 3.50)
        {
            return "Average student.";
        }
        return "Very nice person.";
    }
}