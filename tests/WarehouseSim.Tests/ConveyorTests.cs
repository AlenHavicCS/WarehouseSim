using WarehouseSim.Core;

namespace WarehouseSim.Tests;

public class ConveyorTests
{
    [Fact]
    public void Constructor_WithValidValues_SetsIdAndCapacity()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);

        Assert.Equal("CONV-01", conveyor.Id);
        Assert.Equal(5, conveyor.Capacity);
    }
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithBlankID_ThrowsArgumentException(string badId)
    {
        Assert.Throws<ArgumentException>(() => new Conveyor(badId, 5));
    }
}