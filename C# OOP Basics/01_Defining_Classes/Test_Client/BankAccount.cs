public class BankAccount
{
    public int Id { get; set; }

    public decimal Balance { get; set; }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }
}
