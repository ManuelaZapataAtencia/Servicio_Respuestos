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
    public class VentasController : ApiController
    {
        public IQueryable Get()
        {
            clsVentas _ventas = new clsVentas();
            return _ventas.ListarTodosConRepuesto();
        }

        // GET api/<controller>/5
        public venta Get(int id)
        {
            clsVentas _venta = new clsVentas();
            return _venta.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] venta venta)
        {
            clsVentas _venta = new clsVentas();
            _venta.venta = venta;
            return _venta.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] venta venta)
        {
            clsVentas _venta = new clsVentas();   
            _venta.venta = venta;
            return _venta.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] venta venta)
        {
            clsVentas _venta = new clsVentas();   
            _venta.venta = venta;
            return _venta.Eliminar();
        }
    }
}
