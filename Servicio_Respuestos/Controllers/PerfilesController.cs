using Servicio_Respuestos.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_Jueves.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    [RoutePrefix("api/Perfiles")]
    public class PerfilesController : ApiController
    {
        [HttpGet]
        [Route("ListarPerfiles")]
        public IQueryable ListarPerfiles()
        {
            clsPerfil perfil = new clsPerfil();
            return perfil.ListaPerfiles();
        }
    }
}