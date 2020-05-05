using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    public string Name { get; set; }

    public SoftUniAttribute(string name)
    {
        Name = name;
    }
}
