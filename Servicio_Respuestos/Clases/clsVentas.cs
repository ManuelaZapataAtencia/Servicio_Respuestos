using System;
using System.Collections.Generic;
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

        //Método insertar
        public string Insertar()
        {
            try
            {
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
                venta _venta = Consultar(venta.id_venta);
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
            return dbTaller.venta.FirstOrDefault(e => e.id_venta == id_venta);
        }

        // consulta general
        public List<venta> ConsultarTodos()
        {
            return dbTaller.venta.ToList();
        }
    }
}