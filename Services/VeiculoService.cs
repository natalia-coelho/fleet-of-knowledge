using Interfaces;
using Models;

namespace Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository) =>
        this._vehicleRepository = vehicleRepository;

    public async Task<Vehicle> GetVehicle(Guid id)
    {
        var result = await this._vehicleRepository.GetVehicle(id);
        return result;
    }

    public async Task<Vehicle> Register(Vehicle vehicle)
    {
        var result = await this._vehicleRepository.InsertVehicle(vehicle);
        return result;
    }

    public async Task<Vehicle> Update(Vehicle vehicle, Guid id)
    {
        var result = await this._vehicleRepository.UpdateVehicle(vehicle, id);
        return result;
    }

    public async Task<Vehicle> Delete(Guid id)
    {
        var result = await this._vehicleRepository.DeleteVehicle(id);
        return result;
    }
}
