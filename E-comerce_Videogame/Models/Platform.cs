using Microsoft.AspNetCore.Components.Forms;

namespace E_comerce_Videogame.Models
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relación con Variants
        public ICollection<Variant> Variants { get; set; } = new List<Variant>();
    }
}
