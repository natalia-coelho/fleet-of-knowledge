using fleet_of_knowledge.Models;
using fleet_of_knowledge.Services;
using Microsoft.AspNetCore.Mvc;

namespace fleet_of_knowledge.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService movieService;

    public MoviesController(MovieService movieService) => this.movieService = movieService;

    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
        var moviesList = await this.movieService.GetAllMovies();

        return this.Ok(moviesList);
    }

    [HttpGet("id:length(24)")]
    public async Task<IActionResult> GetMoviesById(string id)
    {
        var movie = await this.movieService.GetMovieById(id);

        return movie == null ? this.NotFound() : this.Ok(movie);
    }

    [HttpGet("title")]
    public async Task<IActionResult> GetMoviesByTitle(string title)
    {
        var movie = await this.movieService.GetMovieByTitle(title);

        return movie == null ? this.NotFound() : this.Ok(movie);
    }

    [HttpPut("id:length(24)")]
    public async Task<IActionResult> UpdateMovie(string id, Movie updatedMovie)
    {
        await this.movieService.UpdateAsyncMovie(id, updatedMovie);
        return this.Ok();
    }

    [HttpPost]
    public async Task<IActionResult> InsertMovie(Movie newMovie)
    {
        await this.movieService.CreateAsyncMovie(newMovie);
        return this.Created();
    }

    [HttpDelete("id:length(24)")]
    public async Task<IActionResult> DeleteMovies(string id)
    {
        await this.movieService.DeleteAsyncMovie(id);
        return this.Accepted("Deleted succesfully");
    }
}
