using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    public class RepuestoController : ApiController
    {
        public IQueryable Get()
        {
            clsRepuesto _repuesto = new clsRepuesto();
            return _repuesto.ListarTodosConTipo();
        }

        // GET api/<controller>/5
        public repuesto Get(string codigo)
        {
            clsRepuesto _repuesto = new clsRepuesto();
            return _repuesto.Consultar(codigo);
        }

        // POST api/<controller>
        public string Post([FromBody] repuesto repuesto)
        {
            clsRepuesto _repuesto = new clsRepuesto();
            _repuesto.repuesto = repuesto;
            return _repuesto.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] repuesto repuesto)
        {
            clsRepuesto _repuesto = new clsRepuesto();
            _repuesto.repuesto = repuesto;
            return _repuesto.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] repuesto repuesto)
        {
            clsRepuesto _repuesto = new clsRepuesto();
            _repuesto.repuesto = repuesto;
            return _repuesto.Eliminar();
        }
    }
}
