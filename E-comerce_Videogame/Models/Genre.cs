using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 6. Genres
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
