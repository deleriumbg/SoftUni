using System;
using System.Linq;
using System.Reflection;

public class Tracker : Attribute
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(Program);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (MethodInfo method in methods)
        {
            if (method.CustomAttributes.Any(x => x.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
