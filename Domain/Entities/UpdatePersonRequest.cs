using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UpdatePersonRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime birthdate { get; set; }
        public string curp { get; set; }
        public string email { get; set; }
        public bool status { get; set; }
    }
}
