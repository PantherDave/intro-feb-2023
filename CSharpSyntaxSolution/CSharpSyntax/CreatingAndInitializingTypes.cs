namespace CSharpSyntax;

public class CreatingAndInitializingTypes
{
    [Fact]
    public void UsingLiteralsToCreateInstancesOfTypes() 
    {
        string myName = "David"; // Initializing
        int myAge = 24;

        Assert.Equal("David", myName);
        Assert.Equal(24, myAge);
    }

}

