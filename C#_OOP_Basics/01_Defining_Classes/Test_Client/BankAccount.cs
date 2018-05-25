public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id { get => id; set => id = value; }
    public decimal Balance { get => balance; set => balance = value; }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }
}
