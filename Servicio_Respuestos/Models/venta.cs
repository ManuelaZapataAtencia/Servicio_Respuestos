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
    
    public partial class venta
    {
        public venta()
        {
            this.garantia = new HashSet<garantia>();
        }
    
        public int codigo { get; set; }
        public Nullable<System.DateTime> fecha_venta { get; set; }
        public string codigo_repuesto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio_total { get; set; }
    
        public virtual ICollection<garantia> garantia { get; set; }
        public virtual repuesto repuesto { get; set; }
    }
}
