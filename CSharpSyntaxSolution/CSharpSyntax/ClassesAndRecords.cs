using NuGet.Frameworks;

namespace CSharpSyntax;

public class ClassesAndRecords
{
    [Fact]
    public void MutatingStuffisBadSometimes()
    {
        var me = GetCustomer();

        Assert.Equal("Jeff", me.Name);

        var other = new Customer
        {
            Name = "Jeff",
            AvailableCredit = 3000
        };

        Assert.Equal(me, other);

        var updatedMe = me with { AvailableCredit = 30000 };
        Assert.Equal(3000, me.AvailableCredit); 
        Assert.Equal(30000, updatedMe.AvailableCredit);
    }

    [Fact]
    public void ConstructorRecord()
    {
        var product = new Product("1919", "Eggs", 12, 1.99M);

        // Assert.Equals("1919", product.Sku);
        // Assert.Equals("Eggs", product.Description);
    }

    private Customer GetCustomer()
    {
        return new Customer
        {
            Name = "Jeff",
            AvailableCredit = 3000
        };
    }
}

public record Customer
{
    public string Name { get; init; } = "";

    public decimal AvailableCredit { get; init; } = 3000;
}

public record Product(string Sku, string Description, int Qty, decimal Price)
{
    public decimal GetCost() => Price;
}
