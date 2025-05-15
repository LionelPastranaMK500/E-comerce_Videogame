using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        // Relación con Games (uno a muchos)
        public ICollection<Game> Games { get; set; }
    }
}
