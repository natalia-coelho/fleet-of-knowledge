using fleet_of_knowledge.Models;

namespace fleet_of_knowledge.Interfaces;

public interface IVeiculoService
{
    public Task<Veiculo> ObterVeiculo();
    public Task<Veiculo> Cadastrar(Veiculo veiculo);
    public Task<Veiculo> Atualizar(Veiculo veiculo, Guid id);
    public Task<Veiculo> Excluir(Guid id);
}
