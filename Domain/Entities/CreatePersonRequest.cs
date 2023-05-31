using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CreatePersonRequest
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string curp { get; set; }
        public DateTime birthdate { get; set; }
        public int numEmployee { get; set; }
        public DateTime startDate { get; set; } = DateTime.Now;
        public string email { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
    }
}
