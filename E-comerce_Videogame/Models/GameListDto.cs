namespace E_comerce_Videogame.Models
{
    public class GameListDto
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
