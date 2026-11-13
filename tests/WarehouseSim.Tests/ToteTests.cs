using WarehouseSim.Core;

namespace WarehouseSim.Tests;

public class ToteTests
{
    // TEST 1: Creating a tote with a valid barcode works.
    [Fact]
    public void Constructor_WithValidBarcode_SetsBarcode()
    {
        string barcode = "T-1042";
        Tote tote = new Tote(barcode);
        Assert.Equal(barcode, tote.Barcode);
    }

    // TEST 2: A blank barcode is rejected.
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithBlankBarcode_Throws(string badBarcode)
    {
        Assert.Throws<ArgumentException>(() => new Tote(badBarcode));
    }

    // TEST 3: A new tote has no destination yet.
    [Fact]
    public void NewTote_HasNoDestination()
    {
        Tote tote = new Tote("T-1001");
        Assert.Null(tote.DestinationLane);
    }

    // TEST 4: Assigning a valid lane works.
    [Fact]
    public void AssignDestination_WithValidLane_SetsDestination()
    {
        Tote tote = new Tote("T-1002");
        tote.AssignDestination(3);
        Assert.Equal(3, tote.DestinationLane);
    }

    // TEST 5: Lane numbers below 1 are rejected.
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AssignDestination_WithInvalidLane_Throws(int badLane)
    {
        Tote tote = new Tote("T-1003");
        Assert.Throws<ArgumentOutOfRangeException>(() => tote.AssignDestination(badLane));
    }
}