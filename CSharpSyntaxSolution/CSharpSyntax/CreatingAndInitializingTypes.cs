using System.Text;

namespace CSharpSyntax;

public class CreatingAndInitializingTypes
{
    string thingy = "Birds";

    [Fact]
    public void UsingLiteralsToCreateInstancesOfTypes()
    {
        // local variabled -- variables that are declared inside a method, or property.
        string myName = "David"; // Initializing
        char mi = 'D';
        int myAge = 24;
        bool isLegalAgeToDrink = myAge >= 21;

        Taco food = new Taco();

        Assert.Equal("David", myName);
        Assert.Equal(24, myAge);
    }

    [Fact]
    public void ImplicitlyTypedLocalVariables()
    {
        // var can be used for local variables, and you must initialize the variable.
        var myName = "David";
        var myAge = 24;

        var favoriteFood = new Taco();

        var myPay = 25.23M;

        Taco lunch = new();

        TransitoryPolicyCommuterRecord record = new();
        var record2 = new TransitoryPolicyCommuterRecord();

        Assert.IsType<Taco>(lunch);
    }

    [Fact]
    public void CurlyBracesCreateScopes()
    {
        Assert.Equal("Birds", thingy);

        var message = "";
        var age = 25;
        if (age >= 21)
        {
            message = "Old enough";
        }

        Assert.Equal(message, "Old enough");
    }

    [Fact]
    public void MutableStringsWithStringBuilders()
    {
        var message = new StringBuilder();

        foreach (var num in Enumerable.Range(1, 10000))
        {
            message.Append(num.ToString() + ", ");
        }

        Assert.True(message.ToString().StartsWith("1, 2, 3, 4"));
    }

    [Fact]
    public void MoreAboutStrings()
    {
        var name = "Bob"; var age = 33; 
        var message = "The name is " + name + " and the age is " + age + ".";
        var message2 = string.Format("The name is {0} and the age is {1} (again, name: {0})", name, age);
        var pay = 120_000.00M;
        var m3 = $"{name} makes {pay:c} a year";
    }

    [Fact]
    public void DoingConversionsOnTypes()
    {
        string myPay = "10000.83";

        if (decimal.TryParse(myPay, out decimal payAsNumber))
        {
            Assert.Equal(10_000.83M, payAsNumber);
        } else
        {
            Assert.True(false);
        }

        var birthdate = DateTime.Parse("12/06/1998");
        Assert.Equal(12, birthdate.Month);
        Assert.Equal(6, birthdate.Day);
        Assert.Equal(1998, birthdate.Year);
    }

}


public class Taco
{

}

public class TransitoryPolicyCommuterRecord
{

}

