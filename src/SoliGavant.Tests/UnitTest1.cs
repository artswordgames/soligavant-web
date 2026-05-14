namespace SoliGavant.Tests;

public class UnitTest1
{
    [Fact]
    public void D20Roll_ShouldBeWithinRange()
    {
        var random = new Random();
        int result = random.Next(1, 21);

        Assert.True(result >= 1);
        Assert.True(result <= 20);
    }
}