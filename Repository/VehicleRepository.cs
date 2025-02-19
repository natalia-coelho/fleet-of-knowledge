using Data;
using Interfaces;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;

namespace Repository;

public class VehicleRepository : IVehicleRepository
{
    private readonly IMongoCollection<Vehicle> _vehicleCollection;

    public VehicleRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        this._vehicleCollection = mongoDatabase.GetCollection<Vehicle>(
            databaseSettings.Value.VehiclesCollectionName);
    }

    public async Task<Vehicle> DeleteVehicle(Guid id)
    {
        var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, id);
        var result = await _vehicleCollection.FindOneAndDeleteAsync(filter);
        return result;
    }

    public async Task<Vehicle> GetVehicle(Guid id)
    {
        var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, id);
        var result = await _vehicleCollection.Find(filter).FirstOrDefaultAsync();
        return result;
    }

    public async Task<Vehicle> InsertVehicle(Vehicle vehicle)
    {
        await _vehicleCollection.InsertOneAsync(vehicle);
        return vehicle;
    }

    public async Task<Vehicle> UpdateVehicle(Vehicle vehicle, Guid id)
    {
        var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, id);
        var updateResult = await _vehicleCollection.ReplaceOneAsync(filter, vehicle);
        if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
        {
            return vehicle;
        }
        return null;
    }
}
