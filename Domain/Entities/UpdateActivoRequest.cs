using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UpdateActivoRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set;}
        public int? employeeId { get; set; }
        public DateTime? assignmentDate { get; set; }
        public DateTime? deadLine { get; set; }
        public DateTime? releaseDate { get; set; }

    }
}
