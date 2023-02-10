using Moq;
namespace StringCalculator;

public class StringCalculatorTests
{
    StringCalculator calculator;
    public StringCalculatorTests()
    {
        calculator = new StringCalculator(new Mock<ILogger>().Object);
    }

    [Fact]
    public void EmptyStringReturnsZero()
    {

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("100", 100)]
    public void SingleDigit(string numbers, int answer)
    {
        var sum = calculator.Add(numbers);
        Assert.Equal(sum, answer);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("3,4,5", 12)]
    [InlineData("10,20,30,40,50", 150)]
    public void MultipleDigits(string numbers, int answer)
    {
        var sum = calculator.Add(numbers);
        Assert.Equal(sum, answer);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("//;\n1;2", 3)]
    public void DifferentDelimiters(string numbers, int answer)
    {
        var sum = calculator.Add(numbers);
        Assert.Equal(sum, answer);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("2,-1")]
    [InlineData("//;4\n-1;-3")]
    public void ThrowsOnNegatives(string numbers)
    {
        var sum = 0;
        try
        {
            sum = calculator.Add(numbers);
        } catch (NegativeNumberFoundException) 
        { 
            // Excected
        }
        Assert.Equal(sum, 0);
    }
}
