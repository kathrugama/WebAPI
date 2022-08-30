using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Datos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PCController : ApiController
    {
        // GET api/<controller>
        public List<DetallesCompu> Get()
        {
            return DetallePC.Mostrar();
        }

        // GET api/<controller>/5
        public DetallesCompu Get(int id)
        {
            return DetallePC.Buscar(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] DetallesCompu detallesCompu)
        {
            return DetallePC.Insertar(detallesCompu);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] DetallesCompu detallesCompu)
        {
            return DetallePC.Editar(detallesCompu);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return DetallePC.Eliminar(id);
        }
    }
}