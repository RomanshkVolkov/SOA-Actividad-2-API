using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Persona Persona { get; set; }
        public int NumEmpleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
    }
}
