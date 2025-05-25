using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 9. Platforms
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Propiedad de navegación
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
