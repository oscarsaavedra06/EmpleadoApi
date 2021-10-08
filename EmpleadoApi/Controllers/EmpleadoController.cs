using EmpleadoApi.Interfaces;
using EmpleadoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly InterfaceEmpleado repo;

        public EmpleadoController(InterfaceEmpleado repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<List<Models.Empleado>> Get()
        {
            return await repo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Models.Empleado> Get(int id)
        {
            return await repo.GetById(id);
        }

        [HttpGet]
        [Route("GetByIdDependence/{id}")]
        public async Task<List<Models.Empleado>> GetByIdDependence(int id)
        {
            return await repo.GetByIdDependence(id);
        }

        [HttpGet]
        [Route("GetWithDependence/{id}")]
        public async Task<EmpleadoDependencia> GetWithDependence(int id)
        {
            return await repo.GetWithDependence(id);
        }

        [HttpGet]
        [Route("GetAllWithDependence")]
        public async Task<List<EmpleadoDependencia>> GetAllWithDependence()
        {
            return await repo.GetAllWithDependence();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Models.Empleado entidad)
        {
            return Ok(await repo.Post(entidad));
        }
        [HttpPut]
        public async Task<ActionResult> Put(Models.Empleado entidad)
        {
            return Ok(await repo.Put(entidad));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await repo.Delete(id));
        }
    }
}
