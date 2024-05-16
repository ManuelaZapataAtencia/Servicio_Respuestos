using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Respuestos.Clases
{
    public class clsDepartamento
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public departamento departamento { get; set; }

        //Método insertar
        public string Insertar()
        {
            try
            {
                dbTaller.departamento.Add(departamento);
                dbTaller.SaveChanges();
                return "Se agregó un nuevo departamento";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}