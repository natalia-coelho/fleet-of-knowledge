using Models;

namespace Interfaces;

public interface IVeiculoRepository
{
    Task<Veiculo> DeleteVehicle(Guid id);
    Task<Veiculo> GetVehicle();
    Task<Veiculo> InsertVehicle(Veiculo veiculo);
    Task<Veiculo> UpdateVehicle(Veiculo veiculo, Guid id);
}
