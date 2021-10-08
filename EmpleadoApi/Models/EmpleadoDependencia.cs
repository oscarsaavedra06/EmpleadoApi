using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadoApi.Models
{
    public class EmpleadoDependencia
    {
        public string NumDocumento { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public Dependencia dependencia { get; set; }
    }
}
