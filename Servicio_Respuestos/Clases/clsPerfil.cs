using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Respuestos.Clases
{
    public class clsPerfil
    {
        private DBTallerMotosEntities dbTaller = new DBTallerMotosEntities();
        public perfil perfil { get; set; }//Si se va a generar el crud
        public IQueryable ListaPerfiles()
        {
            return from perfil P in dbTaller.Set<perfil>()
                   select new
                   {
                       Codigo = P.id,
                       Nombre = P.Nombre
                   };
        }
    }
}