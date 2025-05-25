using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace E_comerce_Videogame.Models
{
    // 3. UserRoles (N-N)
    [PrimaryKey(nameof(UserId), nameof(RoleId))]
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
