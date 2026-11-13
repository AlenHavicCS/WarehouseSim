using System.Configuration.Assemblies;
using System.Net.Http.Headers;
using Newtonsoft.Json.Bson;
using WarehouseSim.Core;
using Xunit.Sdk;

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
    }

    [Fact]
    public void Start_SetsIsRunningToTrue()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);
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

        bool added = conveyor.TryAddTote(tote);

        Assert.False(added);
    }

    [Fact]
    public void TryAddTote_WithNullTote_Throws()
    {
        Conveyor conveyor = new Conveyor("CONV-01", 5);

        Assert.Throws<ArgumentException>(() =>  conveyor.TryAddTote(null!));
    }


}