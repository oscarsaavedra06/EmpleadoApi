using System.ComponentModel.DataAnnotations;

namespace EmpleadoApi.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string NumDocumento { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public int idDependencia { get; set; }
    }
}
