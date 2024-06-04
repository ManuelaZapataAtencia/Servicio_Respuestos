using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Respuestos.Clases
{
    public class clsCliente
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public cliente cliente { get; set; }

        // consulta especifica
        public cliente Consultar(string cedula)
        {
            return dbTaller.cliente.FirstOrDefault(e => e.cedula_cliente == cedula);
        }
    }
}