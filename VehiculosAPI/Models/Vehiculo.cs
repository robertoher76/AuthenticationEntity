using System.ComponentModel.DataAnnotations;

namespace VehiculosAPI.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        public int Anio { get; set; }

        public int? ModeloId { get; set; }
    }
}
