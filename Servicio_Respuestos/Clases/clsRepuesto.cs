using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;
using System.Data.Objects.SqlClient;
using System.Web;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Clases
{
    public class clsRepuesto
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public repuesto repuesto { get; set; }

        //Método insertar
        public string Insertar()
        {
            try
            {
                dbTaller.repuesto.Add(repuesto);
                dbTaller.SaveChanges();
                return "Se insertó el repuesto: " + repuesto.nombre + "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // Metodo actualizar
        public string Actualizar()
        {
            try
            {
                dbTaller.repuesto.AddOrUpdate(repuesto);
                dbTaller.SaveChanges();
                return "Se actualizaron los datos del repuesto: " + repuesto.nombre + " ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // Metodo eliminar
        public string Eliminar()
        {
            try
            {
                repuesto _repuesto = Consultar(repuesto.codigo);
                dbTaller.repuesto.Remove(_repuesto);
                dbTaller.SaveChanges();
                return "Se eliminó el repuesto: " + repuesto.nombre;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        // consulta especifica
        public repuesto Consultar(int codigo)
        {
            return dbTaller.repuesto.FirstOrDefault(e => e.codigo == codigo);
        }

        public IQueryable LlenarCombo(int CodigoCategoria)
        {
            return from r in dbTaller.Set<repuesto>()
                   where r.codigo_categoria == CodigoCategoria
                   select new
                   {
                       Codigo = SqlFunctions.StringConvert((double)r.codigo).Trim() 
                       + "|" + SqlFunctions.StringConvert((double)r.valor_unitario).Trim(),
                       Nombre = r.nombre
                   };
        }

        // Metodo que listara los repuestos en la lista desplegable
        public List<repuesto> ListarRepuestos()
        {
            return dbTaller.repuesto.ToList();
        }

        public IQueryable ListarTodosConCategoria()
        {
            return from c in dbTaller.Set<categoria>()
                   join r in dbTaller.Set<repuesto>()
                   on c.codigo equals r.codigo_categoria
                   orderby r.nombre
                   select new
                   {   
                       Codigo = r.codigo,
                       Nombre = r.nombre,
                       Descripcion = r.descripcion,
                       Categoria = c.nombre,
                       Precio = r.valor_unitario,
                   };
        }
    }
}