using System;

namespace Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double simpleSum = deposit;
            double complexSum = deposit;

            for (int i = 0; i < months; i++)
            {
                simpleSum += deposit * 0.03;
                complexSum += complexSum * 0.027;
            }
            Console.WriteLine($"Simple interest rate: {simpleSum:f2} lv.\r\nComplex interest rate: {complexSum:f2} lv.");
            if (simpleSum > complexSum)
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {simpleSum - complexSum:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {complexSum - simpleSum:f2} lv.");
            }
        }
    }
}
