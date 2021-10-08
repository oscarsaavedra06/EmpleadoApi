using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EmpleadoApi.Data
{
    public class EmpleadoDbContext : DbContext
    {
        public EmpleadoDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Empleado> empleados { get; set; }
    }
}
