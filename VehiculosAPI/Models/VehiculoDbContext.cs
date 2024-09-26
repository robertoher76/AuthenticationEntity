using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VehiculosAPI.Models
{
    public class VehiculoDbContext : IdentityDbContext<Usuario>
    {
        public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options) : base(options)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Siembra de datos para las tablas Marca, Modelo y Vehiculos

            modelBuilder.Entity<Marca>().HasData(
                new Marca
                {
                    Id = 1,
                    Nombre = "Toyota"
                },
                new Marca
                {
                    Id = 2,
                    Nombre = "Ford"
                },
                new Marca
                {
                    Id = 3,
                    Nombre = "Chevrolet"
                }
            );

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo
                {
                    Id = 1,
                    Nombre = "Corolla",
                    MarcaId = 1,
                },
                new Modelo
                {
                    Id = 2,
                    Nombre = "Yaris",
                    MarcaId = 1,
                }
            );

            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo
                {
                    Id = 1,
                    Anio = 2020,
                    ModeloId = 1,
                },
                new Vehiculo
                {
                    Id = 2,
                    Anio = 2021,
                    ModeloId = 1,
                }
            );

        }
    }
}
