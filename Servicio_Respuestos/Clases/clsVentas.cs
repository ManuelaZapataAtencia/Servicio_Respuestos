using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;
using System.Data.Objects.SqlClient;

namespace Servicio_Respuestos.Clases
{
    public class clsVentas
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public venta venta { get; set; }

        private void CalcularPrecioTotal()
        {
            var precioProducto = dbTaller.repuesto
                .Where(r => r.codigo.Equals(venta.codigo_repuesto))
                .Select(r => r.valor_unitario)
                .FirstOrDefault();
            if (precioProducto != 0)
            {
                venta.valor_total = (decimal?)(venta.cantidad * Convert.ToDouble(precioProducto));
            }
        }

        //Método insertar
        public string Insertar()
        {
            try
            {
                //venta.codigo = CalcularNumeroFactura();
                venta.fecha_venta = DateTime.Today;
                //CalcularPrecioTotal();
                dbTaller.venta.Add(venta);
                dbTaller.SaveChanges();
                return "Se ha agregado un nuevo producto al carro";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // Metodo eliminar
        public string Eliminar(int CodigoVenta)
        {
            venta venta = dbTaller.venta.FirstOrDefault(d => d.codigo == CodigoVenta);
            dbTaller.venta.Remove(venta);
            dbTaller.SaveChanges();
            return "Se eliminó el detalle de venta";
        }

        // consulta especifica
        public venta Consultar(int id_venta)
        {
            return dbTaller.venta.FirstOrDefault(e => e.codigo == id_venta);
        }

        public IQueryable LlenarTablaVenta()
        {
            return from r in dbTaller.Set<repuesto>()
                   join v in dbTaller.Set<venta>()
                   on r.codigo equals v.codigo_repuesto
                   select new
                   {
                       Eliminar = "<button type=\"button\" id=\"btnEliminar\" " +
                       "class=\"btn-block btn-sm btn-danger\" " +
                       "onclick=\"Eliminar(" + SqlFunctions.StringConvert((double)v.codigo).Trim() + "" +
                       ")\">ELIMINAR</button>",
                       Codigo = v.codigo,
                       Fecha = v.fecha_venta,
                       Repuesto = r.nombre,
                       Precio = r.valor_unitario,
                       Cantidad = v.cantidad,
                       Total = v.valor_total
                   };
        }
    }
}