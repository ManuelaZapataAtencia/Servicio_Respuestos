using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Clases
{
    public class clsCategoria
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public categoria categoria { get; set; }

        //Método insertar
        public string Insertar()
        {
            try
            {
                dbTaller.categoria.Add(categoria);
                dbTaller.SaveChanges();
                return "Se insertó una nueva categoria";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarCombo()
        {
            return from c in dbTaller.Set<categoria>()
                   select new
                   {
                       Codigo = c.codigo,
                       Nombre = c.nombre
                   };
        }
    }
}