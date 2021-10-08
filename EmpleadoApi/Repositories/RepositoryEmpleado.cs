using EmpleadoApi.Data;
using EmpleadoApi.Interfaces;
using EmpleadoApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpleadoApi.Repositories
{
    public class RepositoryEmpleado : InterfaceEmpleado
    {
        private readonly EmpleadoDbContext context;
        public RepositoryEmpleado(EmpleadoDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var item = await context.empleados.FirstOrDefaultAsync(x => x.Id == id);
            context.empleados.Remove(item);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Empleado>> GetAll()
        {
            return await context.empleados.ToListAsync();
        }

        public async Task<Empleado> GetById(int id)
        {
            return await context.empleados.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Models.Empleado>> GetByIdDependence(int id)
        {
            return await context.empleados.Where(x => x.idDependencia == id).ToListAsync();
        }

        public async Task<EmpleadoDependencia> GetWithDependence(int id)
        {
            EmpleadoDependencia result = new EmpleadoDependencia();
            var employe = await context.empleados.FirstOrDefaultAsync(x => x.Id == id);
            result.NombreEmpleado = employe.NombreEmpleado;
            result.ApellidoEmpleado = employe.ApellidoEmpleado;
            result.NumDocumento = employe.NumDocumento;
            result.Cargo = employe.Cargo;
            result.Telefono = employe.Telefono;
            using (var client = new HttpClient())
            {
                var dependences = await client.GetStringAsync($"http://localhost:10246/api/Dependencia/{employe.idDependencia}");
                var dependenceObject = JsonConvert.DeserializeObject<Dependencia>(dependences);
                result.dependencia = dependenceObject;
            }

            return result;
        }

        public async Task<List<EmpleadoDependencia>> GetAllWithDependence()
        {
            List<EmpleadoDependencia> result = new List<EmpleadoDependencia>();
            var employes = await context.empleados.ToListAsync();
            foreach (var item in employes)
            {
                EmpleadoDependencia obj = new EmpleadoDependencia();

                obj.NombreEmpleado = item.NombreEmpleado;
                obj.ApellidoEmpleado = item.ApellidoEmpleado;
                obj.NumDocumento = item.NumDocumento;
                obj.Cargo = item.Cargo;
                obj.Telefono = item.Telefono;

                using (var client = new HttpClient())
                {
                    var dependence = await client.GetStringAsync($"http://localhost:10246/api/Dependencia/{item.idDependencia}");
                    var dependenceObject = JsonConvert.DeserializeObject<Dependencia>(dependence);
                    obj.dependencia = dependenceObject;
                }
                result.Add(obj);
            }



            return result;
        }
        public async Task<bool> Post(Empleado entidad)
        {
            await context.empleados.AddAsync(entidad);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Put(Empleado entidad)
        {
            var item = await context.empleados.FirstOrDefaultAsync(x => x.Id == entidad.Id);
            item.NombreEmpleado = entidad.NombreEmpleado;
            item.ApellidoEmpleado = entidad.ApellidoEmpleado;
            item.Cargo = entidad.Cargo;
            item.NumDocumento = entidad.NumDocumento;
            item.Telefono = entidad.Telefono;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
