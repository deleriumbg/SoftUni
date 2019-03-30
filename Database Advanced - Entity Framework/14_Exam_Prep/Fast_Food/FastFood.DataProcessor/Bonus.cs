﻿using System.Linq;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
	        var item = context.Items.FirstOrDefault(x => x.Name == itemName);
	        if (item == null)
	        {
	            return $"Item {itemName} not found!";
	        }

	        var oldPrice = item.Price;
	        item.Price = newPrice;
	        context.SaveChanges();
	        return $"{itemName} Price updated from ${oldPrice:F2} to ${item.Price:F2}";
	    }
    }
}
