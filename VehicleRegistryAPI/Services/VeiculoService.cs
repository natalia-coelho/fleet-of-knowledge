using Interfaces;
using Models;

namespace Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository) =>
        this._veiculoRepository = veiculoRepository;

    public async Task<IEnumerable<Veiculo>> GetTodosVeiculos() => await this._veiculoRepository.GetAllVehicles();

    public async Task Atualizar(Veiculo veiculo, Guid id) => await this._veiculoRepository.UpdateVehicle(veiculo, id);

    public async Task Excluir(Guid id) => await this._veiculoRepository.DeleteVehicle(id);

    public async Task Cadastrar(Veiculo veiculo) => await this._veiculoRepository.InsertVehicle(veiculo);
}
