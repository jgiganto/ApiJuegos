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

        public void Comprar(List<int> juegoscomprados,int idcliente,int idjuego)
        {
            foreach(var idjuegos in juegoscomprados)
            {
                Pedidos pedido = new Pedidos();
                pedido.IdCliente = idcliente;
                pedido.Cantidad = 1;
                pedido.Fecha = DateTime.Now;
                Juegos juego = GetJuego(idjuego);
                pedido.Precio = juego.Precio;
                contexto.Pedidos.Add(pedido);                
            }
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