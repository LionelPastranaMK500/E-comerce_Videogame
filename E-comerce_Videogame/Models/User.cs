using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relación con UserRoles (uno a muchos)
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
