namespace WarehouseSim.Core;

// Shared interface for all equipment, so the control system can start, stop and monitor any machine
// without knowing its type. New equipment types work automatically once they implement this interface.
public interface IEquipment
{
    string Id { get; }
    bool IsRunning { get; }

    void Start();

    void Stop();
}