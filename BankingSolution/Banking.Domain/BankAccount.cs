namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M;

    public virtual void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
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

