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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class usuario_perfil
    {
        public int id { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_perfil { get; set; }
        public Nullable<bool> activo { get; set; }
    
        [JsonIgnore]
        public virtual perfil perfil { get; set; }
        [JsonIgnore]
        public virtual usuario usuario { get; set; }
    }
}
