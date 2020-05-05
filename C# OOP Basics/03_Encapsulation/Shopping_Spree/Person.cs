using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> Products { get; set; }

    public string Name
    {
        get { return name; }
        private set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        private set
        {
            Validator.ValidateMoney(value);
            money = value;
        }
    }

    public Person()
    {
        Products = new List<Product>();
    }

    public Person(string name, decimal money):this()
    {
        Name = name;
        Money = money;
    }

    public void TryToBuyProduct(Product product)
    {
        if (this.Money < product.Price)
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
        else
        {
            this.Money -= product.Price;
            this.Products.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
    }

    public override string ToString()
    {
        string productsResult = this.Products.Count > 0 ? string.Join(", ", this.Products) : "Nothing bought";
        return $"{this.Name} - {productsResult}";
    }
}
