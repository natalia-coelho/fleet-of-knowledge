using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculosController : ControllerBase
{
    private readonly IVeiculoService _veiculoService;

    public VeiculosController(IVeiculoService veiculoService)
    {
        this._veiculoService = veiculoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterVeiculo()
    {
        var result = await this._veiculoService.GetTodosVeiculos();

        return result == null ? this.NotFound() : this.Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarVeiculo(Veiculo veiculo)
    {
        await this._veiculoService.Cadastrar(veiculo);

        return this.Ok();
    }

    [HttpPut]
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
