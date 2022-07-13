using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Movimiento> ObtenerMovimientosPorCuenta(int cuentaId, DateTime fechaInicial, DateTime fechaFinal)
        {
            return Find(c => c.CuentaId == cuentaId && c.Fecha >= fechaInicial && c.Fecha <= fechaFinal);
        }

        public IEnumerable<Movimiento> ObtenerMovimientosPorCliente(int clienteId, DateTime fechaInicial, DateTime fechaFinal)
        {
            List<Movimiento> movimientosPorCliente = _context.Movimientos.Where(m => m.Fecha >= fechaInicial && m.Fecha <= fechaFinal).Join(_context.Cuentas,
            movimiento => movimiento.CuentaId,
            cuenta => cuenta.Id,
            (movimiento, cuenta) => new { movimiento, cuenta }).
                Join(_context.Clientes,
                cuenta_movimiento => cuenta_movimiento.cuenta.IdCliente,
                cliente => cliente.Id,
                (cuenta_movimiento, cliente) => new { cuenta_movimiento, cliente }
                ).Where(join => join.cliente.Id == clienteId).Select(s => s.cuenta_movimiento.movimiento).ToList();

            return movimientosPorCliente;
        }
    }
}
