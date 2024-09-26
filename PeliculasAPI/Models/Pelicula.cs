using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Anio { get; set; }
        public int? DirectorId { get; set; }
        public int? GeneroId { get; set; }
    }
}
