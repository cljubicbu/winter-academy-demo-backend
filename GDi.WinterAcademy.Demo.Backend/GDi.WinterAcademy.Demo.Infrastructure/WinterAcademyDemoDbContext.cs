using GDi.WinterAcademy.Demo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDi.WinterAcademy.Demo.Infrastructure
{
    public class WinterAcademyDemoDbContext : DbContext
    {
        public WinterAcademyDemoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    Name = "Arnold Schwarzenegger",
                    DateOfBirth = new DateTime(1947, 7, 30),
                    Nationality = "Austrian-American"
                });

            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 2,
                    Name = "Zoe Salanda",
                    DateOfBirth = new DateTime(1978, 6, 19),
                    Nationality = "American"
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Terminator",
                    MainCharacterId = 1,
                    ReleaseDate = new DateTime(1984, 10, 26),
                    Duration = 107
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 2,
                    Title = "Predator",
                    MainCharacterId = 1,
                    ReleaseDate = new DateTime(1987, 7, 12),
                    Duration = 107
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 3,
                    Title = "Avatar: The Way of Water",
                    MainCharacterId = 2,
                    ReleaseDate = new DateTime(2022, 12, 16),
                    Duration = 192
                });
        }
    }
}
