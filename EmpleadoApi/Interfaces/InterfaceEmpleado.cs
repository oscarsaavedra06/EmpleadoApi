using EmpleadoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadoApi.Interfaces
{
    public interface InterfaceEmpleado
    {
        Task<List<Models.Empleado>> GetAll();
        Task<Models.Empleado> GetById(int id);
        Task<List<Models.Empleado>> GetByIdDependence(int id);
        Task<EmpleadoDependencia> GetWithDependence(int id);
        Task<List<EmpleadoDependencia>> GetAllWithDependence();
        Task<bool> Post(Models.Empleado entidad);
        Task<bool> Put(Models.Empleado entidad);
        Task<bool> Delete(int id);
    }
}
