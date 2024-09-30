

using System.ComponentModel.DataAnnotations;

namespace Projeto_Filmes.Models
{
    public class Movie
    {
        [Key]
        [Required]

        public int Id { get; set; }

        [Required(ErrorMessage = "Film Title is required")]
        [MaxLength(100, ErrorMessage = "The title must contain less than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Film Genre is required")]
        public string Genres { get; set; }
        [Required(ErrorMessage ="Film time is required")]
        [Range(70,700, ErrorMessage = "The duration of the film must be between 70min and 700min")]
        public int Duration { get; set; }
        
    }
}
