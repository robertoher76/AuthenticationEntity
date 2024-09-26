using System.ComponentModel.DataAnnotations;

namespace VehiculosAPI.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

    }
}
