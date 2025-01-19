using fleet_of_knowledge.Models;

namespace fleet_of_knowledge.Interfaces;

public interface IVeiculoRepository
{
    Task<Veiculo> DeleteVehicle(Guid id);
    Task<Veiculo> GetVehicle();
    Task<Veiculo> InsertVehicle(Veiculo veiculo);
    Task<Veiculo> UpdateVehicle(Veiculo veiculo, Guid id);
}
