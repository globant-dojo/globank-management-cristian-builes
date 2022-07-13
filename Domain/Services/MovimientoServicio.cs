using Common.Constants;
using Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Static;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public class MovimientoServicio : IMovimientoServicio
    {
        private IUnitOfWork _unitOfWork;

        public MovimientoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Actualizar(Movimiento movimiento)
        {
            Movimiento movimientoActualizar = _unitOfWork.Movimientos.GetById(movimiento.Id.Value);

            if (movimientoActualizar == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.RegistroInexistente, Mensaje.RegistroInexistente);
            }

            movimientoActualizar.Fecha = movimiento.Fecha ?? movimientoActualizar.Fecha;
            movimientoActualizar.Saldo = movimiento.Saldo ?? movimientoActualizar.Saldo;
            movimientoActualizar.Valor = movimiento.Valor ?? movimientoActualizar.Valor;
            movimientoActualizar.TipoMovimientoId = movimiento.TipoMovimientoId ?? movimientoActualizar.TipoMovimientoId;
            _unitOfWork.Complete();
        }

        public void Borrar(int Id)
        {
            Movimiento movimiento = _unitOfWork.Movimientos.GetById(Id);

            if (movimiento == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.RegistroInexistente, Mensaje.RegistroInexistente);
            }

            _unitOfWork.Movimientos.Remove(movimiento);
            _unitOfWork.Complete();
        }

        public void Crear(Movimiento movimiento)
        {
            if (movimiento.Id != null)
            {
                throw new BancoBuilesException(CodigoExcepcion.Id, Mensaje.Id);
            }

            Cuenta cuenta = _unitOfWork.Cuentas.GetById(movimiento.CuentaId.GetValueOrDefault());

            if (cuenta == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.CuentaInexistente, Mensaje.CuentaInexistente);
            }

            if (movimiento.Valor < 0 || movimiento.Valor == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.ValorNoSoportado, Mensaje.ValorNoSoportado);
            }

            ITipoMovimiento tipoMovimiento = FabricaTipoMovimiento.ObtenerInstancia(_unitOfWork, movimiento.TipoMovimientoId.GetValueOrDefault());
            tipoMovimiento.RealizarMovimiento(cuenta, movimiento);
        }

        public Movimiento ObtenerMovimiento(int Id)
        {
            return _unitOfWork.Movimientos.GetById(Id);
        }

        public IEnumerable<Movimiento> ObtenerMovimientos()
        {
            return _unitOfWork.Movimientos.GetAll();
        }

        public IEnumerable<Movimiento> ObtenerMovimientosPorCuenta(int cuentaId, DateTime fechaInicial, DateTime fechaFinal)
        {
            return _unitOfWork.Movimientos.ObtenerMovimientosPorCuenta(cuentaId, fechaInicial, fechaFinal);
        }

        public IEnumerable<Movimiento> ObtenerMovimientosPorCliente(int clienteId, DateTime fechaInicial, DateTime fechaFinal)
        {
            return _unitOfWork.Movimientos.ObtenerMovimientosPorCliente(clienteId, fechaInicial, fechaFinal);
        }
    }
}
