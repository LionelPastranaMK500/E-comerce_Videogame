using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(4000)] // NVARCHAR(MAX) mapeado como StringLength(4000) por simplicidad
        public string Description { get; set; }

        // Relación con Games (uno a muchos)
        public ICollection<Game> Games { get; set; }
    }
}
