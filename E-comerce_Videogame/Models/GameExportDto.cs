namespace E_comerce_Videogame.Models
{
    public class GameExportDto
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? precio { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public string GenreName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
