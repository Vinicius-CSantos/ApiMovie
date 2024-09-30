
using AutoMapper;
using Projeto_Filmes.Data.Dtos;
using Projeto_Filmes.Models;


namespace Projeto_Filmes.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMoviesDto>();
    }
}
