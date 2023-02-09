namespace Banking.UnitTests.BonusCalculations;

public class StandardBonusCalculatorTestsDuringBusinessHours
{
    private StandardBonusCalculator _calculator;
    public StandardBonusCalculatorTestsDuringBusinessHours()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);
        _calculator = new StandardBonusCalculator(stubbedClock.Object);
    }
    // 1. Deposits under the cutoff amount get no bonus. (5000)
    [Fact]
    public void UnderCutoffGetNoBonus()
    {
        var bonus = _calculator.GetDepositBonusFor(4999.99M, 100);
        Assert.Equal(0, bonus);
    }
    [Fact]
    public void AtCutoffGetsBonus()
    {
        var bonus = _calculator.GetDepositBonusFor(5000M, 100);
        Assert.Equal(10, bonus);
    }
    // 2. Deposits with 5000+ during Business Hours get a bonus.
    // 3. Deposits with 5000+ outside of Business Hours get no bonus.
}