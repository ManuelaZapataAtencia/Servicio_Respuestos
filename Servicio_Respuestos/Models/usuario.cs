//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio_Respuestos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public usuario()
        {
            this.usuario_perfil = new HashSet<usuario_perfil>();
        }
    
        public int id { get; set; }
        public string cedula_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string clave { get; set; }
        public string salt { get; set; }
    
        public virtual empleado empleado { get; set; }
        public virtual ICollection<usuario_perfil> usuario_perfil { get; set; }
    }
}
