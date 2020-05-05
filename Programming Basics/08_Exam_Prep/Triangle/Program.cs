using System;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (!(a < b + c) || !(b < a + c) || !(c < a + b))
            {
                Console.WriteLine($"There is no triangle with sides {a.ToString("0.#")}, {b.ToString("0.#")} and {c.ToString("0.#")}. ");
            }
            else if (!(a == b) && !(b == c) && !(a == c))
            {
                Console.WriteLine($"Triangle with sides {a.ToString("0.#")}, {b.ToString("0.#")} and {c.ToString("0.#")} is scalene.");
            }
            else if (a == b && b == c)
            {
                Console.WriteLine($"Triangle with sides {a.ToString("0.#")}, {b.ToString("0.#")} and {c.ToString("0.#")} is equilateral.");
            }
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine($"Triangle with sides {a.ToString("0.#")}, {b.ToString("0.#")} and {c.ToString("0.#")} is isosceles.");
            }
        }
    }
}
