using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? CategoryId { get; set; }

        public int? PublisherId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relaciones de navegación
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
