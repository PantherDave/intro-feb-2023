
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("100", 100)]
    public void SingleDigit(string numbers, int answer)
    {
        var calculator = new StringCalculator();
        var sum = calculator.Add(numbers);
        Assert.Equal(sum, answer);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("3,4,5", 12)]
    [InlineData("10,20,30,40,50", 150)]
    public void MultipleDigits(string numbers, int answer)
    {
        var calculator = new StringCalculator();
        var sum = calculator.Add(numbers);
        Assert.Equal(sum, answer);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("//;\n1;2", 3)]
    public void DifferentDelimiters(string numbers, int answer)
    {
        var calculator = new StringCalculator();
        var sum = calculator.Add(numbers);
        Assert.Equal(sum, answer);
    }
}
