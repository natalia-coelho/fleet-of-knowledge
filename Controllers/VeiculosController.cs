using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

public class VeiculosController : ControllerBase
{
    private readonly VeiculoService _veiculoService;

    public VeiculosController(VeiculoService veiculoService)
    {
        this._veiculoService = veiculoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterVeiculo(Veiculo veiculo)
    {
        var result = await this._veiculoService.GetTodosVeiculos();

        return result == null ? this.NotFound() : this.Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarVeiculo(Veiculo veiculo)
    {
        await this._veiculoService.Cadastrar(veiculo);

        return this.Created();
    }

    [HttpPatch]
    public async Task<IActionResult> AtualizarVeiculo(Veiculo veiculo, Guid id)
    {
        await this._veiculoService.Atualizar(veiculo, id);

        return this.Accepted(veiculo);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletarVeiculo(Guid id)
    {
        await this._veiculoService.Excluir(id);

        return this.Accepted();
    }
}
