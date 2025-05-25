using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 5. Publishers
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        // Propiedad de navegación
        public virtual ICollection<Game> Games { get; set; }
    }
}
