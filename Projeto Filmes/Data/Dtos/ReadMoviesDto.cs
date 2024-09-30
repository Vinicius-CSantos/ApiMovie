using System.ComponentModel.DataAnnotations;

namespace Projeto_Filmes.Data.Dtos;

public class ReadMoviesDto
{
    
    public string Title { get; set; }
    public string Genres { get; set; }
    public int Duration { get; set; }

    public DateTime TimeConsult {  get; set; } = DateTime.Now;
}
