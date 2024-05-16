using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicio_Respuestos.Models;

namespace Servicio_Respuestos.Clases
{
    public class clsCiudad
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public ciudad ciudad { get; set; }

        //Método insertar
        public string Insertar()
        {
            try
            {
                dbTaller.ciudad.Add(ciudad);
                dbTaller.SaveChanges();
                return "Se agregó una nueva ciudad";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}