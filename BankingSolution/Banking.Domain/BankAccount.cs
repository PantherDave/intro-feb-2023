namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M;
    private ICanCalculateAccountBonuses _bonusCalculator;

    public BankAccount(ICanCalculateAccountBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public void Deposit(decimal amountToDeposit)
    {
        // Write the code you wish you had.
        decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
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