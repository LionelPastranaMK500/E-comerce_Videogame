using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    // 2. Users
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

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Propiedad de navegación
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
