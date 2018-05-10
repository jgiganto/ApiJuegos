using ApiJuegos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiJuegos.Controllers
{
    public class JuegosController : ApiController
    {
        ModeloJuegos modelo;
        public JuegosController()
        {
            this.modelo = new ModeloJuegos();
        }

        [HttpGet]
        [Route("api/ListaJuegos")]
        public List<Juegos> ListaJuegos()
        {
            return modelo.GetJuegos();
        }
        [HttpGet]
        [Route("api/Juego/{idjuego}")]
        public Juegos Juego(int IdJuego)
        {
            return modelo.GetJuego(IdJuego);
        }

        [HttpPost]
        [Route("api/Comprar/{juegoscomprados}/{idcliente}/{idjuego}")]
        public void Comprar(List<int> juegoscomprados, int idcliente, int idjuego)
        {
            this.modelo.Comprar(juegoscomprados, idcliente, idjuego);
        }

        [HttpGet]
        [Route("api/ListaPedidos/{idcliente}")]
        public List<Pedidos> ListaPedidos(int idcliente)
        {
            return modelo.GetPedidosCliente(idcliente);
        }
         

    }
}
