using Microsoft.EntityFrameworkCore;
using Projeto_Filmes.Models;

namespace Projeto_Filmes.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts): base(opts) 
    {

    }

    public DbSet<Movie> movies { get; set; }
}
