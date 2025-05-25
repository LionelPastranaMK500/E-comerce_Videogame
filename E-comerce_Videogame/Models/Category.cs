using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 4. Categories
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        // Propiedad de navegación
        public virtual ICollection<Game> Games { get; set; }
    }
}
