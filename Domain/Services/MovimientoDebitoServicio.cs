using Common.Constants;
using Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class MovimientoDebitoServicio : ITipoMovimiento
    {
        private IUnitOfWork _unitOfWork;

        public MovimientoDebitoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RealizarMovimiento(Cuenta cuenta, Movimiento movimiento)
        {
            if (cuenta.Saldo < movimiento.Valor)
            {
                throw new BancoBuilesException(CodigoExcepcion.SaldoInsuficiente, Mensaje.SaldoInsuficiente);
            }

            cuenta.Saldo -= movimiento.Valor;
            movimiento.Saldo = cuenta.Saldo;

            _unitOfWork.Movimientos.Add(movimiento);
            _unitOfWork.Complete();
        }
    }
}
