using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpleadoVM
    {
        public int Id { get; set; }
        [JsonPropertyName("No. Empleado")]
        public string NumEmpleado { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("Apellidos")]
        public string Apellidos { get; set; }
        [JsonPropertyName("CURP")]
        public string CURP { get; set; }
        [JsonPropertyName("Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        [JsonPropertyName("Correo")]
        public string Correo { get; set; }
        [JsonPropertyName("Estado")]
        public string Estado { get; set; }
    }
}
