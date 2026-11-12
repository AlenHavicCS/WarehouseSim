namespace WarehouseSim.Core;

// A tote is the container that moves through the warehouse.
public class Tote
{
    public string Barcode { get; }

    public int? DestinationLane { get; private set; }

    public Tote(string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode))
        {
            throw new ArgumentException("Barcode cannot be blank.");
        }

        Barcode = barcode;
    }

    public void AssignDestination(int lane)
    {
        if (lane < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(lane), "Lane must be a positive integer.");
        }

        DestinationLane = lane;
    }
}