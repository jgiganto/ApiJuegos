using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiJuegos.Models
{
    public class ModeloClientes
    {
        ContextoJuegos contexto;
        public ModeloClientes()
        {
            this.contexto = new ContextoJuegos();
        }

        public void InsertarCliente(int idcliente,String nombre,String apellido,String login,String pass)
        {
            Clientes clientes = new Clientes();
            clientes.IdCliente = idcliente;
            clientes.Nombre = nombre;
            clientes.Apellido = apellido;
            clientes.Login = login;
            clientes.Pass = pass;
            contexto.Clientes.Add(clientes);
            contexto.SaveChanges();
        }

    }
}