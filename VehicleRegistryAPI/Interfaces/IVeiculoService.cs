using Models;

namespace Interfaces;

public interface IVeiculoService
{
    public Task<IEnumerable<Veiculo>> GetTodosVeiculos();
    public Task Cadastrar(Veiculo veiculo);
    public Task Atualizar(Veiculo veiculo, Guid id);
    public Task Excluir(Guid id);
}
