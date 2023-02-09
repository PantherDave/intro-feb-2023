namespace Banking.UnitTests;

public class GoldCustomersGetBonusOnDeposit
{
    [Fact]
    public void BonusAppliedToDeposit() 
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit); 

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}
