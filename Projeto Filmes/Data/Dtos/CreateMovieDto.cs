using System.ComponentModel.DataAnnotations;

namespace Projeto_Filmes.Data.Dtos;

public class CreateMovieDto
{
    [Required(ErrorMessage = "Film Title is required")]
    [StringLength(100, ErrorMessage = "The title must contain less than 100 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Film Genre is required")]
    public string Genres { get; set; }
    [Required(ErrorMessage = "Film time is required")]
    [Range(70, 700, ErrorMessage = "The duration of the film must be between 70min and 700min")]
    public int Duration { get; set; }

}
