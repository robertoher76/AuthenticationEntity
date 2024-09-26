using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
