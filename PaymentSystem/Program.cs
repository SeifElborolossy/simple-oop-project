class BankAccount
{
    public string Name;
    public int AccountBalance { get; private set; }

    public BankAccount(string name, int amount)
    {
        Name = name;
        SetAccountBalance(amount);
    }
    public void SetAccountBalance(int amount)
    {
        AccountBalance = amount;
    }
}

interface IPayable
{
    void Pay(int amount);
}

interface IRefundable
{
    void Refund(int amount);
}

class CheckingAccount : BankAccount, IPayable, IRefundable
{
    public string Type { get; private set; }
    public CheckingAccount(string name, int amount) : base(name, amount)
    {
        Type = "CheckingAccount";
    }
    public void Pay(int amount)
    {
        if (AccountBalance < amount)
        {
            Console.WriteLine($"You don't have the necessary funds, your current balance is {AccountBalance}");
            return;
        }
        else if (amount <= 0)
        {
            Console.WriteLine($"Please choose a number higher than a 0 and lower than {AccountBalance}");
            return;

        }
        SetAccountBalance(AccountBalance - amount);
    }

    public void Refund(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount needs to be positive.");
            return;
        }
        SetAccountBalance(AccountBalance + amount);
    }
}