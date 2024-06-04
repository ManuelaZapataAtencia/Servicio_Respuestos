using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Servicio_Respuestos.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        // GET api/<controller>/5
        public cliente Get(string cedula)
        {
            clsCliente _cliente = new clsCliente();
            return _cliente.Consultar(cedula);
        }
    }
}
