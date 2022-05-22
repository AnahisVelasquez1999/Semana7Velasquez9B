using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Semana7Velasquez9B.Models
{
    public class Estudiante
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Usurio { get; set; }

        [MaxLength(255)]
        public string Contrasena { get; set; }
    }
}
