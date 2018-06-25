using System;
using System.Numerics;

namespace Anonymous_Downsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int affectedWebsites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0.0m;

            for (int i = 0; i < affectedWebsites; i++)
            {
                string[] websitesData = Console.ReadLine().Split(' ');
                string siteName = websitesData[0];
                long siteVisits = long.Parse(websitesData[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(websitesData[2]);
                decimal siteLoss = siteVisits * siteCommercialPricePerVisit;
                totalLoss += siteLoss;
                Console.WriteLine($"{siteName}");
            }

            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, affectedWebsites)}");
        }
    }
}
