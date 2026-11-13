namespace WarehouseSim.Core;

public class Conveyor
{
    public string Id { get; }
    public int Capacity { get; }

    public Conveyor(string id, int capacity)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Conveyor ID cannot be blank.", nameof(id));
        }
        Id = id;
        Capacity = capacity;
    }
}