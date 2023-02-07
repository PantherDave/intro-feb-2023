namespace Demo1.UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // throw new Exception();
    }

    [Fact]
    public void CanAddTwoNumbers()
    {
        // Given (Arrange)
        int a = 10, b = 20, c;
        // When (Act)
        c = a + b;
        // Then (Assert)
        Assert.Equal(c, 30);
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(8, 3, 11)]
    [InlineData(3, 4, 8)]
    public void CanAddTwoNumbersTheory(int a, int b, int expected) 
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }
}
