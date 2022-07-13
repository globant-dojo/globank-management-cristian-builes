using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IMovimientoServicio
    {
        IEnumerable<Movimiento> ObtenerMovimientos();
        IEnumerable<Movimiento> ObtenerMovimientosPorCuenta(int cuentaId, DateTime fechaInicial, DateTime fechaFinal);
        IEnumerable<Movimiento> ObtenerMovimientosPorCliente(int clienteId, DateTime fechaInicial, DateTime fechaFinal);
        Movimiento ObtenerMovimiento(int Id);
        void Crear(Movimiento movimiento);
        void Actualizar(Movimiento movimiento);
        void Borrar(int Id);
    }
}
