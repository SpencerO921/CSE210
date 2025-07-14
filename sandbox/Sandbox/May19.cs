public class Account
{
    public List<int> _transactions = new List<int>(); // if we change this to a list...
    private int _balance = int.MinValue;

    public void Deposit(int amount)
    {
        transactions.Add(amount);
        _balance = int.MinValue;
    }
    public void SetBalance(int balance)
    {
        _balance = balance;
    }


    public int GetBalance()
    {
        if (_balance == int.MinValue)
        {
            int runningBalance = 0;
            foreach (int amount in _transactions)
            {
                runningBalance += amount;
            }
            _balance = runningBalance;
        }
        return _balance;
    }
}