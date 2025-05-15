using Microsoft.AspNetCore.Components.Forms;

namespace E_comerce_Videogame.Models
{
    public class Variant
    {
        public int VariantId { get; set; }
        public int EditionId { get; set; }
        public int PlatformId { get; set; }
        public int StockQuantity { get; set; }
        public decimal PriceAdjustment { get; set; }

        // Propiedades de navegación
        public Edition Edition { get; set; } = null!;
        public Platform Platform { get; set; } = null!;
    }
}
