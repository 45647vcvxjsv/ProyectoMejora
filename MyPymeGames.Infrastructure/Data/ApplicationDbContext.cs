using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using MyPymeGames.Core.Entities;

namespace MyPymeGames.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // datos iniciales 
            modelBuilder.Entity<User>().HasData(
                new User {Id = 1, Username = "admin", Email = "admin@mypymegames.com", PasswordHash = "AQAAAAEAACcQAAAAEJ9"},
                new User {Id = 2, Username = "usuario1", Email = "usuario1@example.com", PasswordHash = "Anotherpassword"},
                new User {Id = 3, Username = "usuario2", Email = "usuario2@example.com", PasswordHash = "Anotherpassword2"},
                new User {Id = 4, Username = "usuario3", Email = "usuario3@example.com", PasswordHash = "Anotherpassword3"}
            );
        }
    }   
}