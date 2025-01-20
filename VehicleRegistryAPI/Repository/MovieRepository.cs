using Data;
using Interfaces;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;

namespace Repository;

public class MovieRepository : IMovieRepository
{
    private readonly IMongoCollection<Movie> _movieCollection;

    public MovieRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        this._movieCollection = mongoDatabase.GetCollection<Movie>(
            databaseSettings.Value.MoviesCollectionName);
    }

    public async Task<IEnumerable<Movie>> GetAllMovies() =>
        await this._movieCollection
            .Find(_ => true)
            .Limit(10)
            .ToListAsync();

    public async Task<Movie> GetMovieById(string id) => await this._movieCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Movie> GetMovieByTitle(string title) => await this._movieCollection.Find(x => x.Title == title).FirstOrDefaultAsync();

    public async Task UpdateMovie(string id, Movie updatedMovie) => await this._movieCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);

    public async Task CreateMovie(Movie newMovie) =>
        await this._movieCollection.InsertOneAsync(newMovie);

    public async Task DeleteMovie(string id) => await this._movieCollection.DeleteOneAsync(x => x.Id == id);
}
