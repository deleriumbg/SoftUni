using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            FieldInfo privateValue = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            //To create instance of a private class we have to use the constructor overload
            //that receives bool nonPublic after the class type.
            object instance = Activator.CreateInstance(classType, true);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split('_');
                string command = inputArgs[0];
                int inputValue = int.Parse(inputArgs[1]);

                MethodInfo currentMethod = classMethods.First(x => x.Name == command);
                //Invoke method always needs to recieve its parameters as an array of objects.
                currentMethod.Invoke(instance, new object[] {inputValue});
                Console.WriteLine(privateValue.GetValue(instance));
                input = Console.ReadLine();
            }
        }
    }
}