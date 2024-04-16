using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
                dbTaller.repuestoes.Add(repuesto);
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
                dbTaller.repuestoes.AddOrUpdate(repuesto);
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
                dbTaller.repuestoes.Remove(_repuesto);
                dbTaller.SaveChanges();
                return "Se eliminó el repuesto: " + repuesto.nombre;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        // consulta especifica
        public repuesto Consultar(string codigo)
        {
            return dbTaller.repuestoes.FirstOrDefault(e => e.codigo == codigo);
        }

        // consulta general
        public List<repuesto> ConsultarTodos()
        {
            return dbTaller.repuestoes.ToList();
        }

        public IQueryable ListarTodosConTipo()
        {
            return from c in dbTaller.Set<categoria>()
                   join r in dbTaller.Set<repuesto>()
                   on c.codigo equals r.codigo_categoria
                   orderby c.nombre, r.nombre
                   select new
                   {
                       Codigo_Categoria = c.codigo,
                       Categoria = c.nombre,
                       Codigo = r.codigo,
                       Nombre = r.nombre,
                       Descripcion = r.descripcion,
                       Precio = r.precio,
                   };
        }
    }
}