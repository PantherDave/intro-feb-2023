using Banking.Domain;

namespace Banking.UnitTests;

public class MakingWithdrawals
{
    private decimal _openingBalance = 5000M;
    private BankAccount _account = new BankAccount(new DummyBonusCalculator());

    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    public void MakingAWithdrawalDecresesBalance(decimal amountToWithdraw)
    {
        _account = new BankAccount(new DummyBonusCalculator());
        _openingBalance = _account.GetBalance();

        _account.Withdraw(amountToWithdraw);

        Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        Assert.Throws<AccountOverdraftException>(() => _account.Withdraw(_openingBalance + .01M));
    }

    [Fact]
    public void OverdraftIsNotAllowedBalanceStaysTheSame()
    {
        var amountToWithdraw = _openingBalance + .01M;
        try
        {
            _account.Withdraw(amountToWithdraw);
        }
        catch (AccountOverdraftException)
        {
            // This was expected
        }
        Assert.Equal(_openingBalance, _account.GetBalance());
    }

    [Fact]
    public void CanTakeEntireBalance()
    {
        _account = new BankAccount(new DummyBonusCalculator());

        _account.Withdraw(_account.GetBalance());

        Assert.Equal(0, _account.GetBalance());
    }
}
