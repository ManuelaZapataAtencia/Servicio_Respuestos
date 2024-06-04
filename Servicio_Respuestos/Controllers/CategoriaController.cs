using Servicio_Respuestos.Clases;
using Servicio_Respuestos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicio_Respuestos.Controllers
{
    [EnableCors(origins: "http://localhost:53331", headers: "*", methods: "*")]
    [RoutePrefix("api/Categoria")]
    
    public class CategoriaController : ApiController
    {
        // GET api/<controller>
        public List<categoria> Get()
        {
            clsListas _listas = new clsListas();
            return _listas.ConsultarCategorias();
        }

        // POST api/<controller>
        public string Post([FromBody] categoria categoria)
        {
            clsCategoria _categoria = new clsCategoria();
            _categoria.categoria = categoria;
            return _categoria.Insertar();
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsCategoria _categoria = new clsCategoria();
            return _categoria.LlenarCombo();
        }
    }
}
