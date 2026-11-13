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

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithCapacityBelowOne_Throws(int badCapacity)
    {
        Assert.Throws<ArgumentException>(() => new Conveyor("CONV-01", badCapacity));
    }

    [Fact]
    public void NewConveyor_IsNotRunning()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        Assert.False(conveyor.IsRunning);
    }

    [Fact]
    public void Start_SetsIsRunningToTrue()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        conveyor.Start();

        Assert.True(conveyor.IsRunning);
    }

    [Fact]
    public void Stop_AfterStart_SetsIsRunningToFalse()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        conveyor.Start();

        conveyor.Stop();

        Assert.False(conveyor.IsRunning);
    }

    [Fact]
    public void Conveyor_CanBeUsedAsIEquipment()
    {
        IEquipment equipment = new Conveyor("CONV-01", 5);

        equipment.Start();

        Assert.True(equipment.IsRunning);
    }

    [Fact]
    public void TryAddTote_WhenNotFull_ReturnsTrueAndAddsTote()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        Tote tote = new Tote("T-1");

        bool added = conveyor.TryAddTote(tote);

        Assert.True(added);
        Assert.Equal(1, conveyor.ToteCount);
    }

    [Fact]
    public void TryAddTote_WhenFull_ReturnsFalse()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 1);
        Tote tote = new Tote("T-1");
        Tote tote2 = new Tote("T-2");
        conveyor.TryAddTote(tote);
        bool added = conveyor.TryAddTote(tote2);

        Assert.False(added);
    }

    [Fact]
    public void TryAddTote_WithNullTote_Throws()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);

        Assert.Throws<ArgumentNullException>(() =>  conveyor.TryAddTote(null!));
    }

    [Fact]
    public void ReleaseTote_ReturnsTotesInTheOrderTheyEntered()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        conveyor.Start();
        conveyor.TryAddTote(new Tote("T-1"));
        conveyor.TryAddTote(new Tote("T-2"));

        Tote? first = conveyor.ReleaseTote();
        Tote? second = conveyor.ReleaseTote();

        Assert.Equal("T-1", first?.Barcode);
        Assert.Equal("T-2", second?.Barcode);

    }

    [Fact]
    public void ReleaseTote_WhenEmpty_ReturnsNull()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        conveyor.Start();

        Tote? released = conveyor.ReleaseTote();

        Assert.Null(released);
    }
    
    [Fact]
    public void ReleaseTote_WhenStopped_ReturnsNullAndKeepsTote()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
        conveyor.TryAddTote(new Tote("T-1"));
        Tote? released = conveyor.ReleaseTote();

        Assert.Null(released);
        Assert.Equal(1, conveyor.ToteCount);
    }
}