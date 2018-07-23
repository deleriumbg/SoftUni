using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder result = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        result.AppendLine($"Class under investigation: {classToInvestigate}");
        foreach (FieldInfo field in classFields.Where(x => fieldsToInvestigate.Contains(x.Name)))
        {
            result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return result.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder result = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public!");
        }
        foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        return result.ToString().TrimEnd();
    }
}
