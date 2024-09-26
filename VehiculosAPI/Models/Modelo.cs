using System.ComponentModel.DataAnnotations;

namespace VehiculosAPI.Models
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public int? MarcaId { get; set; }
    }
}
