using E_comerce_Videogame.Models;
using System.ComponentModel.DataAnnotations;

public class Game
{
    [Key]
    public int GameId { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    public string Description { get; set; }

    public double? precio { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public int? CategoryId { get; set; }

    public string CategoryName { get; set; }

    public int? PublisherId { get; set; }

    public string PublisherName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int? GenreId { get; set; }

    public string GenreName { get; set; }

    // Propiedades de navegación
    public virtual Category Category { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual ICollection<Edition> Editions { get; set; }
}