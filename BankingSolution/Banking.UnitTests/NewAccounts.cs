

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void NewAccoutnsHaveTheCorrewctOpeningBalance()
    {
        var account = new BankAccount(new Mock<ICanCalculateAccountBonuses>().Object);

        decimal openingBalance = account.GetBalance();

        Assert.Equal(5_000M, openingBalance);
    }
}