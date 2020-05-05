using System;

class PriceChangeAlert
{
    static void Main()
    {
        int numberOfPrices = int.Parse(Console.ReadLine());
        double significanceThreshold = double.Parse(Console.ReadLine());
        double firstPrice = double.Parse(Console.ReadLine());

        for (int curretPrice = 0; curretPrice < numberOfPrices - 1; curretPrice++)
        {
            double nextPrice = double.Parse(Console.ReadLine());
            double difference = Percentage(firstPrice, nextPrice);
            bool isSignificantDifference = isDifferent(difference, significanceThreshold);

            string result = GetDifference(firstPrice, nextPrice, difference, isSignificantDifference);
            Console.WriteLine(result);
            firstPrice = nextPrice;
        }
        
    }

    private static string GetDifference(double firstPrice, double nextPrice, double difference, bool isSignificantDifference)
    {
        string printDifference = "";
        if (difference == 0)
        {
            printDifference = string.Format("NO CHANGE: {0}", firstPrice);
        }
        else if (!isSignificantDifference)
        {
            printDifference = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", firstPrice, nextPrice, difference * 100);
        }
        else if (isSignificantDifference && (difference > 0))
        {
            printDifference = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", firstPrice, nextPrice, difference * 100);
        }
        else if (isSignificantDifference && (difference < 0))
            printDifference = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", firstPrice, nextPrice, difference * 100);
        return printDifference;
    }
    private static bool isDifferent(double difference, double significanceThreshold)
    {
        if (Math.Abs(difference) >= significanceThreshold)
        {
            return true;
        }
        return false;
    }

    private static double Percentage(double firstPrice, double nextPrice)
    {
        double prercentage = (nextPrice - firstPrice) / firstPrice;
        return prercentage;
    }
}
