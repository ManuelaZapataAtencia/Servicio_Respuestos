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
    public class ProveedorController : ApiController
    {
        public IQueryable Get()
        {
            clsProveedor _proveedor = new clsProveedor();
            return _proveedor.ListarTodosConCiudad();
        }

        // GET api/<controller>/5
        public proveedor Get(string id)
        {
            clsProveedor _proveedor = new clsProveedor();
            return _proveedor.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] proveedor proveedor)
        {
            clsProveedor _proveedor = new clsProveedor();
            _proveedor.proveedor = proveedor;
            return _proveedor.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] proveedor proveedor)
        {
            clsProveedor _proveedor = new clsProveedor();
            _proveedor.proveedor = proveedor;
            return _proveedor.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete([FromBody] proveedor proveedor)
        {
            clsProveedor _proveedor = new clsProveedor();
            _proveedor.proveedor = proveedor;
            return _proveedor.Eliminar();
        }
    }
}
