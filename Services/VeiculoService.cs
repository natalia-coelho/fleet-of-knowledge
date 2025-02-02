using Interfaces;
using Models;

namespace Services;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository) =>
        this._veiculoRepository = veiculoRepository;

    public async Task<Veiculo> ObterVeiculo()
    {
        var result = await this._veiculoRepository.GetVehicle();
        return result;
    }

    public async Task<Veiculo> Atualizar(Veiculo veiculo, Guid id)
    {
        var result = await this._veiculoRepository.UpdateVehicle(veiculo, id);

        return result;
    }

    public async Task<Veiculo> Excluir(Guid id)
    {
        var result = await this._veiculoRepository.DeleteVehicle(id);

        return result;
    }

    public async Task<Veiculo> Cadastrar(Veiculo veiculo)
    {
        var result = await this._veiculoRepository.InsertVehicle(veiculo);

        return result;
    }
}
