using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Activo_Empleado
    {
        [Key]
        public int Id { get; set; }
        public Empleado Empleado { get; set; }
        public Activo Activo { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        
        public DateTime? FechaLiberacion { get; set; }
    }
}
