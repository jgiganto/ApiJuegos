using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiJuegos.Models
{
    public class ModeloJuegos
    {
        ContextoJuegos contexto;
        public ModeloJuegos()
        {
            this.contexto = new ContextoJuegos();
        }

        public List<Juegos> GetJuegos()
        {
            var consulta = from datos in contexto.Juegos
                           select datos;
            return consulta.ToList();
        }

        public Juegos GetJuego(int IdJuego)
        {
            var consulta = from datos in contexto.Juegos
                           where datos.IdJuego == IdJuego
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void Comprar(int idcliente,int idjuego)
        {
            var consulta = from datos in contexto.ListaPedidos
                           select datos;
            int max = consulta.Count() + 1;
            ListaPedidos pedido = new ListaPedidos();
            Juegos juego = this.GetJuego(idjuego);

            pedido.IdPedido = max;
            pedido.Precio = juego.Precio;
            pedido.Fecha = DateTime.Now;
            pedido.IdJuego = idjuego;
            pedido.IdCliente = idcliente;
            pedido.Titulo = juego.Titulo;
            contexto.ListaPedidos.Add(pedido);
            contexto.SaveChanges();
        }

        public List<Pedidos> GetPedidosCliente(int idcliente)
        {
            var consulta = from datos in contexto.Pedidos
                           where datos.IdCliente == idcliente
                           select datos;
            return consulta.ToList();
        }
    }
}