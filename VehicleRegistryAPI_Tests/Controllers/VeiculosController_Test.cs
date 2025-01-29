using Controllers;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;

namespace VehicleRegistryAPI.Tests.Controllers;

public class VeiculosController_Test
{
    private readonly Mock<IVeiculoService> _mockVeiculoService;
    private readonly VeiculosController _controller;

    public VeiculosController_Test()
    {
        this._mockVeiculoService = new Mock<IVeiculoService>();
        this._controller = new VeiculosController(this._mockVeiculoService.Object);
    }

    [Fact]
    public async Task ObterVeiculo_ReturnsOkResult_WithListOfVehicles()
    {
        // Arrange
        var vehicles = new List<Veiculo> { new Veiculo(), new Veiculo() };
        this._mockVeiculoService.Setup(service => service.GetTodosVeiculos()).ReturnsAsync(vehicles);

        // Act
        var result = await this._controller.ObterVeiculo();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Veiculo>>(okResult.Value);
        Assert.Equal(vehicles.Count, returnValue.Count);
    }

    [Fact]
    public async Task CadastrarVeiculo_ReturnsCreatedResult()
    {
        // Arrange
        var vehicle = new Veiculo();

        // Act
        var result = await this._controller.CadastrarVeiculo(vehicle);

        // Assert
        Assert.IsType<CreatedResult>(result);
        this._mockVeiculoService.Verify(service => service.Cadastrar(vehicle), Times.Once);
    }

    [Fact]
    public async Task AtualizarVeiculo_ReturnsAcceptedResult()
    {
        // Arrange
        var vehicle = new Veiculo();
        var id = Guid.NewGuid();

        // Act
        var result = await this._controller.AtualizarVeiculo(vehicle, id);

        // Assert
        Assert.IsType<AcceptedResult>(result);
        this._mockVeiculoService.Verify(service => service.Atualizar(vehicle, id), Times.Once);
    }

    [Fact]
    public async Task DeletarVeiculo_ReturnsAcceptedResult()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = await this._controller.DeletarVeiculo(id);

        // Assert
        Assert.IsType<AcceptedResult>(result);
        this._mockVeiculoService.Verify(service => service.Excluir(id), Times.Once);
    }
}
