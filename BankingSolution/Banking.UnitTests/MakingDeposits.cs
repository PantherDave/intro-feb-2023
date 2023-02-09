namespace Banking.UnitTests;

public class MakingDeposits
{
    [Fact]
    public void DepositingMoneyIncreasesTheBalance()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    } 
}
