using Microsoft.Ajax.Utilities;
using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;
using Servicios_PD.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace Servicios_PD.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("Ingresar")]
        public IQueryable Ingresar(LoginCliente login)
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.ConsultarUsuario(login);
        }
    }
}