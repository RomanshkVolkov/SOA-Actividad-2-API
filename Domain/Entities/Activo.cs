﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Activo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(255)]
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
