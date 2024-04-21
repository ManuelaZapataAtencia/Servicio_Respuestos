using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Respuestos.Clases
{
    public class clsListas
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public categoria categoriaRepuesto { get; set; }
        public ciudad ciudadProveedor { get; set; }
        public List<categoria> ConsultarCategorias()
        {
            return dbTaller.categoria.OrderBy(c => c.nombre).ToList();
        }
        public List<ciudad> ConsultarCiudades()
        {
            return dbTaller.ciudad.OrderBy(c => c.nombre).ToList();
        }
    }
}