using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MG.Empleados.BM;
using MG.Empleados.DT;

namespace MG.Empleados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        // GET: api/Empleado
        [HttpGet]
        public List<DTEmpleado> Get()
        {
            BMEmpleados objNegocio = new BMEmpleados();
            List<DTEmpleado> ListaEmpleados = new List<DTEmpleado>();
            ListaEmpleados = objNegocio.ConsultarEmpleado();
            return ListaEmpleados;
        }

        // GET: api/Empleado/5
        [HttpGet("{id}", Name = "Get")]
        public List<DTEmpleado> Get(int id)
        {
            BMEmpleados objNegocio = new BMEmpleados();
            List<DTEmpleado> ListaEmpleados = new List<DTEmpleado>();
            ListaEmpleados = objNegocio.ConsultarEmpleado(id);
            return ListaEmpleados;
        }

    }
}
