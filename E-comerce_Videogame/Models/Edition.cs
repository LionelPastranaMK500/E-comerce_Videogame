using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 8. Editions
    public class Edition
    {
        [Key]
        public int EditionId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public decimal BasePrice { get; set; }

        // Propiedad de navegación
        public virtual Game Game { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
