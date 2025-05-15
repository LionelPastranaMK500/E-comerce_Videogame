namespace E_comerce_Videogame.Models
{
    public class Edition
    {
        public int EditionId { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }

        // Propiedades de navegación
        public Game Game { get; set; } = null!;
        public ICollection<Variant> Variants { get; set; } = new List<Variant>();
    }
}
