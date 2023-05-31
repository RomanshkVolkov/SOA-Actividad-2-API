using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActivoEmpleadoVM
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool Empleado_Estado { get; set; }
        public int Activo_Id { get; set; }
        public string Activo_Nombre { get; set; }
        public string FechaAsignacion { get; set; }
        public string FechaEntrega { get; set; }
        public DateTime? FechaLiberacion { get; set; }
    }
}
