namespace Demo1.UnitTest
{
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
    }
}