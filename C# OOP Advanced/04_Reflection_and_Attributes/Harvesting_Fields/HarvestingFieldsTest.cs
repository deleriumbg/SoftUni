 using System.Collections.Generic;
 using System.Linq;
 using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = Type.GetType("P01_HarvestingFields.HarvestingFields");
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string command = Console.ReadLine();
            while (command != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;
                switch (command)
                { 
                    case "private":
                        fieldsToPrint = classFields.Where(x => x.IsPrivate);
                        break;
                    case "protected":
                        fieldsToPrint = classFields.Where(x => x.IsFamily);
                        break;
                    case "public":
                        fieldsToPrint = classFields.Where(x => x.IsPublic);
                        break;
                    case "all":
                        fieldsToPrint = classFields;
                        break;
                }

                foreach (var field in fieldsToPrint)
                {
                    Print(field);
                }

            command = Console.ReadLine();
            }
        }

        private static void Print(FieldInfo field)
        {
            string accessModifier = field.Attributes.ToString().ToLower();
            if (accessModifier == "family")
            {
                accessModifier = "protected";
            }
            Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
        }
    }
}
