using fleet_of_knowledge.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace fleet_of_knowledge.Services;

public class MovieService
{
    private readonly IMongoCollection<Movie> _movieCollection;

    public MovieService(IOptions<MovieStoreDatabaseSettings> movieStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            movieStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            movieStoreDatabaseSettings.Value.DatabaseName);

        this._movieCollection = mongoDatabase.GetCollection<Movie>(
            movieStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Movie>> GetAllMovies() =>
        await this._movieCollection
            .Find(_ => true)
            .Limit(10)
            .ToListAsync();

    public async Task<Movie> GetMovieById(string id) => await this._movieCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Movie> GetMovieByTitle(string title) => await this._movieCollection.Find(x => x.Title == title).FirstOrDefaultAsync();

    public async Task UpdateAsyncMovie(string id, Movie updatedMovie) => await this._movieCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);

    public async Task CreateAsyncMovie(Movie newMovie) =>
        await this._movieCollection.InsertOneAsync(newMovie);

    public async Task DeleteAsyncMovie(string id) => await this._movieCollection.DeleteOneAsync(x => x.Id == id);

    // TO-DOS: create repository to lead with database connections
}
