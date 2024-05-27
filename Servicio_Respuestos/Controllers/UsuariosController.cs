using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_Jueves.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    [AllowAnonymous]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
        public string CrearUsuario(usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
                _usuario.usuario = usuario;
            return _usuario.Insertar(idPerfil);
        }
        [HttpPut]
        [Route("ActualizarUsuario")]
        public string ActualizarUsuario(usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Actualizar(idPerfil);
        }
        [HttpPut]
        [Route("DesactivarUsuario")]
        public string DesactivarUsuario(usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.ActivarUsuario(usuario.cedula_usuario, false);
        }
        [HttpPut]
        [Route("ActivarUsuario")]
        public string ActivarUsuario(usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.ActivarUsuario(usuario.cedula_usuario, true);
        }
    }
}