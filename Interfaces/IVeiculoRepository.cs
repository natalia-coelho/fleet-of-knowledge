using Models;

namespace Interfaces;

public interface IVehicleRepository
{
    Task<Vehicle> DeleteVehicle(Guid id);
    Task<Vehicle> GetVehicle(Guid id);
    Task<Vehicle> InsertVehicle(Vehicle vehicle);
    Task<Vehicle> UpdateVehicle(Vehicle vehicle, Guid id);
}
