using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Servicio_Respuestos.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    public class CategoriaController : ApiController
    {
        // GET api/<controller>
        public List<categoria> Get()
        {
            clsCategoria _categoriaRepuesto = new clsCategoria();
            return _categoriaRepuesto.ConsultarCategorias();
        }
    }
}
