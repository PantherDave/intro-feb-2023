namespace Banking.UnitTests;

public class BankAccountDepositsUseTheBonusCalculator
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        // Given
        var account = new BankAccount(new StubbedBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 118.32M;
        // When
        account.Deposit(amountToDeposit); // <- THIS IS THE SYSTEM UNDER TEST
        // Then
        Assert.Equal(openingBalance + amountToDeposit + 42.18M, account.GetBalance());
    }
}
