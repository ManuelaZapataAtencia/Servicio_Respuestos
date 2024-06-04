using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    [RoutePrefix("api/Repuesto")]
    
    public class RepuestoController : ApiController
    {

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsRepuesto _producto = new clsRepuesto();
            return _producto.LlenarCombo();
        }
        public IQueryable Get()
        {
            clsRepuesto _repuesto = new clsRepuesto();
            return _repuesto.ListarTodosConCategoria();
        }

        // GET api/<controller>/5
        public repuesto Get(int codigo)
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
