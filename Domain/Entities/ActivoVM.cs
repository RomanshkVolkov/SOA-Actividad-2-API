using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActivoVM
    {
        [JsonPropertyName("No. Activo")]
        public int Id { get; set; }
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("Descripción")]
        public string Descripcion { get; set; }
        [JsonPropertyName("Estado")]
        public string Estado { get; set; }
    }
}
