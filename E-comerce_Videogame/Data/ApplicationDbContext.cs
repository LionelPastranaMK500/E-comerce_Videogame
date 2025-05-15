using Microsoft.EntityFrameworkCore;
using E_comerce_Videogame.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace E_comerce_Videogame.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Variant> Variants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves primarias compuestas
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Relaciones
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Games)
                .WithOne(g => g.Category)
                .HasForeignKey(g => g.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Games)
                .WithOne(g => g.Publisher)
                .HasForeignKey(g => g.PublisherId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Editions)
                .WithOne(e => e.Game)
                .HasForeignKey(e => e.GameId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Edition>()
                .HasMany(e => e.Variants)
                .WithOne(v => v.Edition)
                .HasForeignKey(v => v.EditionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Variants)
                .WithOne(v => v.Platform)
                .HasForeignKey(v => v.PlatformId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
