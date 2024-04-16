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
    
    public partial class repuesto
    {
        public repuesto()
        {
            this.compatibilidad = new HashSet<compatibilidad>();
            this.venta = new HashSet<venta>();
        }
    
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string codigo_categoria { get; set; }
        [JsonIgnore]
        public virtual categoria categoria { get; set; }
        [JsonIgnore]
        public virtual ICollection<compatibilidad> compatibilidad { get; set; }
        [JsonIgnore]
        public virtual ICollection<venta> venta { get; set; }
    }
}
