using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Respuestos.Models
{
    public class LoginCliente
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Error { get; set; }
    }
    public class LoginRespuesta
    {
        public string Token { get; set; }
        public string Perfil { get; set; }
        public bool Autenticado { get; set; }
        public string PaginaNavegar { get; set; }
        public string Error { get; set; }
    }
}