using Interfaces;
using Models;

namespace Services;

public class MovieService
{
    private readonly IMovieRepository _MovieRepository;

    // construtor
    public MovieService(IMovieRepository movieRepository) => this._MovieRepository = movieRepository;

    public async Task<IEnumerable<Movie>> GetAllMovies() =>
        await this._MovieRepository.GetAllMovies();

    public async Task<Movie> GetMovieById(string id) =>
        await this._MovieRepository.GetMovieById(id);

    public async Task<Movie> GetMovieByTitle(string title) =>
        await this._MovieRepository.GetMovieByTitle(title);

    public async Task UpdateAsyncMovie(string id, Movie updatedMovie) =>
        await this._MovieRepository.UpdateMovie(id, updatedMovie);

    public async Task CreateAsyncMovie(Movie newMovie) =>
        await this._MovieRepository.CreateMovie(newMovie);

    public async Task DeleteAsyncMovie(string id) =>
        await this._MovieRepository.DeleteMovie(id);
}
