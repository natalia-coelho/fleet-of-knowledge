using fleet_of_knowledge.Models;

namespace fleet_of_knowledge.Interfaces;

public interface IVeiculoRepository
{
    Task<Veiculo> GetVehicle();
}
