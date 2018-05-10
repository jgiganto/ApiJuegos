using ApiJuegos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiJuegos.Controllers
{
    public class ClientesController : ApiController
    {
        ModeloClientes modelo;
        public ClientesController()
        {
            this.modelo = new ModeloClientes();
        }

       [HttpPost]
        [Route("api/InsertarCliente/{idcliente}/{nombre}/{apellido}/{login}/{pass}")]
        public void InsertarCliente(int Idcliente, String Nombre, String Apellido, String Login, String Pass)
        {
            this.modelo.InsertarCliente(Idcliente, Nombre, Apellido, Login, Pass);

        }
          
        
    }
}
