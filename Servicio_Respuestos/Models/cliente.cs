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
    
    public partial class cliente
    {
        public string cedula_cliente { get; set; }
        public string nombre { get; set; }
        public Nullable<int> edad { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string id_moto { get; set; }
    
        public virtual moto moto { get; set; }
    }
}