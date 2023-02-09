namespace Banking.Domain;

public enum LoyaltyLevel { Standard, Gold };

public class BankAccount
{
    private decimal _balance = 5000M;
    public LoyaltyLevel Level;
    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = 0;
        if (Level == LoyaltyLevel.Gold)
        {
            bonus = (amountToDeposit * .10M);
        }
        _balance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (NotOverdraft(amountToWithdraw)) 
        {
            _balance -= amountToWithdraw;
        } else
        {
            throw new AccountOverdraftException();
        }
    }

    private bool NotOverdraft(decimal amountToWithdarw)
    {
        return _balance >= amountToWithdarw;
    }
}

