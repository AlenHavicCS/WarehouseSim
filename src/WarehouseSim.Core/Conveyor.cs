namespace WarehouseSim.Core;

public class Conveyor : IEquipment
{
    public string Id { get; }
    public int Capacity { get; }
    public bool IsRunning {get; private set;}
    private readonly Queue<Tote> _totes = new();
    public int ToteCount => _totes.Count;
    public bool IsFull => ToteCount >= Capacity;

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

    public bool TryAddTote(Tote tote)
    {
        ArgumentNullException.ThrowIfNull(tote);
        if (IsFull)
        {
            return false;
        }
        _totes.Enqueue(tote);
        return true;
    }

    public Tote? ReleaseTote()
    {
        if (!IsRunning)
        {
            return null;
        }else if(ToteCount == 0)
        {
            return null;
        }
        return _totes.Dequeue();
    }
}