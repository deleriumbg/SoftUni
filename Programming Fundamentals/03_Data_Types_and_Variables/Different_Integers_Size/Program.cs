using System;

namespace Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool canFit = false;
            string result = "";

            try
            {
                sbyte num = sbyte.Parse(input);
                canFit = true;
                result += "* sbyte\r\n";
            }
            catch { }
            try
            {
                byte num = byte.Parse(input);
                canFit = true;
                result += "* byte\r\n";
            }
            catch { }
            try
            {
                short num = short.Parse(input);
                canFit = true;
                result += "* short\r\n";
            }
            catch { }
            try
            {
                ushort num = ushort.Parse(input);
                canFit = true;
                result += "* ushort\r\n";
            }
            catch { }
            try
            {
                int num = int.Parse(input);
                canFit = true;
                result += "* int\r\n";
            }
            catch { }
            try
            {
                uint num = uint.Parse(input);
                canFit = true;
                result += "* uint\r\n";
            }
            catch { }
            try
            {
                long num = long.Parse(input);
                canFit = true;
                result += "* long\r\n";
            }
            catch { }
            if (canFit)
            {
                Console.WriteLine($"{input} can fit in:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}
