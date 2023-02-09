namespace Banking.UnitTests;

public class GoldCustomersGetBonusOnDeposit
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        var account = new GoldBankAccount();
        var amountToDeposit = 100M;
        var openingBalance = account.GetBalance();

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}
