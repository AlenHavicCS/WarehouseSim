namespace WarehouseSim.Core;

public class Conveyor : IEquipment
{
    public string Id { get; }
    public int Capacity { get; }
    public bool IsRunning {get; private set;}

    public void Start()
    {
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public Conveyor(string id, int capacity)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Conveyor ID cannot be blank.", nameof(id));
        }
        if(capacity < 1)
        {
            throw new ArgumentException("Capacity must be at least 1.", nameof(capacity));
        }
        Id = id;
        Capacity = capacity;
    }    


}