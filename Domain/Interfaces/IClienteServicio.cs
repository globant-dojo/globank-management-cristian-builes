using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IClienteServicio
    {
        IEnumerable<Cliente> ObtenerClientes();
        Cliente ObtenerCliente(int Id);
        void CrearCliente(Cliente cliente);
        void ActualizarCliente(Cliente cliente);
        void BorrarCliente(int Id);
    }
}
