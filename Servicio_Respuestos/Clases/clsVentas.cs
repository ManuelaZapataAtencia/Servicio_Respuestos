using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Clases
{
    public class clsVentas
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public venta venta { get; set; }

        public void CalcularPrecioTotal()
        {
            var precioProducto = dbTaller.repuesto
                .Where(r => r.codigo.Equals(venta.codigo_repuesto))
                .Select(r => r.precio)
                .FirstOrDefault();
            if (precioProducto != null)
            {
                venta.precio_total = (decimal?)(venta.cantidad * Convert.ToDouble(precioProducto));
            }
        }

        //Método insertar
        public string Insertar()
        {
            try
            {
                CalcularPrecioTotal();
                dbTaller.venta.Add(venta);
                dbTaller.SaveChanges();
                return "Se ha insertado una nueva venta";
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
                CalcularPrecioTotal();
                dbTaller.venta.AddOrUpdate(venta);
                dbTaller.SaveChanges();
                return "Se ha actualizado la venta";
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
                venta _venta = Consultar(venta.codigo);
                dbTaller.venta.Remove(_venta);
                dbTaller.SaveChanges();
                return "se ha eliminado la venta";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // consulta especifica
        public venta Consultar(int id_venta)
        {
            return dbTaller.venta.FirstOrDefault(e => e.codigo == id_venta);
        }

        // consulta general
        public List<venta> ConsultarTodos()
        {
            return dbTaller.venta.ToList();
        }

        public IQueryable ListarTodosConRepuesto()
        {
            return from r in dbTaller.Set<repuesto>()
                   join v in dbTaller.Set<venta>()
                   on r.codigo equals v.codigo_repuesto
                   orderby r.nombre
                   select new
                   {
                       Codigo = v.codigo,
                       Fecha = v.fecha_venta,
                       Repuesto = r.nombre,
                       Precio = r.precio,
                       Cantidad = v.cantidad,
                       Total = v.precio_total
                   };
        }
    }
}