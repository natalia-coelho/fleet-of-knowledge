using Data;
using Interfaces;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;

namespace Repository;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly IMongoCollection<Veiculo> _vehicleCollection;

    public VeiculoRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        this._vehicleCollection = mongoDatabase.GetCollection<Veiculo>(
            databaseSettings.Value.VehiclesCollectionName);
    }

    public Task<Veiculo> DeleteVehicle(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Veiculo> GetVehicle()
    {
        throw new NotImplementedException();
    }

    public Task<Veiculo> InsertVehicle(Veiculo veiculo)
    {
        throw new NotImplementedException();
    }

    public Task<Veiculo> UpdateVehicle(Veiculo veiculo, Guid id)
    {
        throw new NotImplementedException();
    }
}
