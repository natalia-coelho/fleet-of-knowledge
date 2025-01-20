using Models;

namespace Interfaces;

public interface IVeiculoRepository
{
    public Task<IEnumerable<Veiculo>> GetAllVehicles();
    public Task InsertVehicle(Veiculo veiculo);
    public Task UpdateVehicle(Veiculo veiculo, Guid id);
    public Task DeleteVehicle(Guid id);
}
