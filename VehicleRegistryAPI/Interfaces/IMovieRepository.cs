using Models;

namespace Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllMovies();
    Task<Movie> GetMovieById(string id);
    Task<Movie> GetMovieByTitle(string title);
    Task CreateMovie(Movie newMovie);
    Task UpdateMovie(string id, Movie updatedMovie);
    Task DeleteMovie(string id);
}
