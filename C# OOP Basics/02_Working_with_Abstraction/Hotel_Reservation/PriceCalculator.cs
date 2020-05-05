using System;

public class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDays;
    private Seasons season;
    private Discounts discount;

    public void ParseInput(string input)
    {
        string[] inputArgs = input.Split();
        pricePerDay = decimal.Parse(inputArgs[0]);
        numberOfDays = int.Parse(inputArgs[1]);
        season = Enum.Parse<Seasons>(inputArgs[2]);
        discount = Discounts.None;
        if (inputArgs.Length > 3)
        {
            discount = Enum.Parse<Discounts>(inputArgs[3]);
        }
    }

    public decimal CalculatePrice()
    {
        decimal totalPrice = pricePerDay * numberOfDays * (int) season;
        decimal totalDiscount = (100 - (int)discount) / 100.0M;
        totalPrice *= totalDiscount;
        return totalPrice;
    }
}
