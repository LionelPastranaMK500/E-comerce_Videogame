using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 10. Variants
    public class Variant
    {
        [Key]
        public int VariantId { get; set; }

        [Required]
        public int EditionId { get; set; }

        [Required]
        public int PlatformId { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } = 0;

        [Range(-999999.99, 999999.99)]
        public decimal PriceAdjustment { get; set; } = 0.00m;

        // Propiedades de navegación
        public virtual Edition Edition { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
