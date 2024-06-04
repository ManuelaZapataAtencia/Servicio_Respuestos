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
    [RoutePrefix("api/Ventas")]
    
    public class VentasController : ApiController
    {
        [HttpGet]
        [Route("LlenarTablaVenta")]
        public IQueryable LlenarTablaVenta()
        {
            clsVentas _ventas = new clsVentas();
            return _ventas.LlenarTablaVenta();
        }

        // POST api/<controller>
        [HttpPost]
        [Route("AgregarProducto")]
        public string AgregarProducto([FromBody] venta venta)
        {
            clsVentas _venta = new clsVentas();
            _venta.venta = venta;
            return _venta.Insertar();
        }

        [HttpDelete]
        [Route("EliminarVenta")]
        public string EliminarVenta(int CodigoVenta)
        {
            clsVentas facturacion = new clsVentas();
            return facturacion.Eliminar(CodigoVenta);
        }
    }
}
