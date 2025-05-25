using System.ComponentModel.DataAnnotations;

namespace E_comerce_Videogame.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Propiedad de navegación
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
