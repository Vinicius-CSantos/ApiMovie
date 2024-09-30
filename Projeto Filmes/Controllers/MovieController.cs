
using Projeto_Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto_Filmes.Data;
using Projeto_Filmes.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Projeto_Filmes.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _movieContext;
    private IMapper _mapper;
    public MovieController(MovieContext movieContext, IMapper mapper)
    {
        _movieContext = movieContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddFilm(
        [FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _movieContext.movies.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(MoviePerId), new { id = movie.Id }, movie);

    }

    [HttpGet]
    public IEnumerable<ReadMoviesDto> RecoveryMovie([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {

        return _mapper.Map<List<ReadMoviesDto>>(_movieContext.movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]

    public IActionResult? MoviePerId(int id)
    {

        var movies = _movieContext.movies.FirstOrDefault(Movie => Movie.Id == id);
        if (movies == null) return NotFound();
        var movieDto = _mapper.Map<ReadMoviesDto>(movies);
        return Ok(movieDto);

    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _movieContext.movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();


        _mapper.Map(movieDto, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMovieParam(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _movieContext.movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();

        var patchMovie = _mapper.Map<UpdateMovieDto>(movie);
        patch.ApplyTo(patchMovie, ModelState);

        if (!TryValidateModel(patchMovie))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(patchMovie, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id) 
    {
        var movie = _movieContext.movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();

        _movieContext.Remove(movie);
        _movieContext.SaveChanges();
        return NoContent();
    }
}
