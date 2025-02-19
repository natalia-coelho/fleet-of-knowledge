using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        this._vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVehicle(Vehicle vehicle, Guid id)
    {
        var result = await this._vehicleService.GetVehicle(id);

        return result == null ? this.NotFound() : this.Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterVehicle(Vehicle vehicle)
    {
        await this._vehicleService.Register(vehicle);

        return this.Created();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateVehicle(Vehicle vehicle, Guid id)
    {
        var result = await this._vehicleService.Update(vehicle, id);

        return result == null ? this.NotFound() : this.Accepted(vehicle);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        var result = await this._vehicleService.Delete(id);

        return this.Accepted(result);
    }
}
