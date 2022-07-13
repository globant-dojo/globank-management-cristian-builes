using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IMovimientoRepository : IGenericRepository<Movimiento>
    {
        IEnumerable<Movimiento> ObtenerMovimientosPorCuenta(int cuentaId, DateTime fechaInicial, DateTime fechaFinal);
        IEnumerable<Movimiento> ObtenerMovimientosPorCliente(int clienteId, DateTime fechaInicial, DateTime fechaFinal);
    }
}
