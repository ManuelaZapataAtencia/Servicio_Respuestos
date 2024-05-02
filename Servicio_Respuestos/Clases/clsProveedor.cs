using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Clases
{
    public class clsProveedor
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public proveedor proveedor { get; set; }

        //Método insertar
        public string Insertar()
        {
            try
            {
                dbTaller.proveedor.Add(proveedor);
                dbTaller.SaveChanges();
                return "Se ha registrado al proveedor: " + proveedor.nombre + "";
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
                dbTaller.proveedor.AddOrUpdate(proveedor);
                dbTaller.SaveChanges();
                return "Se actualizaron los datos del proveedor: " + proveedor.nombre + "";
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
                proveedor _proveedor = Consultar(proveedor.nit);
                dbTaller.proveedor.Remove(_proveedor);
                dbTaller.SaveChanges();
                return "se ha eliminado al proveedor: " + proveedor.nombre + "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // consulta especifica
        public proveedor Consultar(string nit)
        {
            return dbTaller.proveedor.FirstOrDefault(e => e.nit == nit);
        }

        // consulta general
        public List<proveedor> ConsultarTodos()
        {
            return dbTaller.proveedor.ToList();
        }

        public IQueryable ListarTodosConCiudad()
        {
            return from c in dbTaller.Set<ciudad>()
                   join p in dbTaller.Set<proveedor>()
                   on c.codigo equals p.codigo_ciudad
                   orderby p.nit
                   select new
                   {
                       Nit = p.nit,
                       Nombre = p.nombre,
                       Telefono = p.telefono,
                       Ciudad = c.nombre,
                   };
        }
    }
}