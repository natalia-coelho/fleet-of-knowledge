using Models;

namespace Interfaces;

public interface IVehicleService
{
    public Task<Vehicle> GetVehicle(Guid id);
    public Task<Vehicle> Register(Vehicle vehicle);
    public Task<Vehicle> Update(Vehicle vehicle, Guid id);
    public Task<Vehicle> Delete(Guid id);
}
