using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Models
{
    public class PeliculaDbContext : IdentityDbContext<Usuario>
    {
        public PeliculaDbContext(DbContextOptions<PeliculaDbContext> options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Director> Directores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Siembra de datos para las tablas Marca, Modelo y Vehiculos

            modelBuilder.Entity<Genero>().HasData(
                new Genero
                {
                    Id = 1,
                    Nombre = "Drama"
                },
                new Genero
                {
                    Id = 2,
                    Nombre = "Romance"
                },
                new Genero
                {
                    Id = 3,
                    Nombre = "Ficción"
                }
            );

            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 1,
                    Nombre = "Francis Ford Coppola"
                },
                new Director
                {
                    Id = 2,
                    Nombre = "Anthony Minghella"
                }
            );

            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    Id = 1,
                    Nombre = "El padrino",
                    Anio = 1972,
                    GeneroId = 1,
                    DirectorId = 1
                },
                new Pelicula
                {
                    Id = 2,
                    Nombre = "El paciente inglés",
                    Anio = 1999,
                    GeneroId = 2,
                    DirectorId = 2
                }
            );

        }
    }
}
