public class Product
{
    private string name;
    private decimal price;

    public string Name
    {
        get { return name; }
        private set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public decimal Price
    {
        get { return price; }
        private set
        {
            Validator.ValidateMoney(value);
            price = value;
        }
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return this.Name;
    }
}
