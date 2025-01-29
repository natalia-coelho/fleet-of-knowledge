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

    public async Task<IEnumerable<Veiculo>> GetAllVehicles() =>
        await this._vehicleCollection
            .Find(_ => true)
            .ToListAsync();

    public async Task InsertVehicle(Veiculo veiculo) => await this._vehicleCollection.InsertOneAsync(veiculo);

    public async Task UpdateVehicle(Veiculo veiculo, Guid id) => await this._vehicleCollection.ReplaceOneAsync(v => v.Id == id, veiculo);

    public async Task DeleteVehicle(Guid id) => await this._vehicleCollection.DeleteOneAsync(v => v.Id == id);
}
