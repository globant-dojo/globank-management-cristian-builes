using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class MovimientoCreditoServicio : ITipoMovimiento
    {
        private IUnitOfWork _unitOfWork;

        public MovimientoCreditoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RealizarMovimiento(Cuenta cuenta, Movimiento movimiento)
        {
            cuenta.Saldo += movimiento.Valor;
            movimiento.Saldo = cuenta.Saldo;

            _unitOfWork.Movimientos.Add(movimiento);
            _unitOfWork.Complete();
        }
    }
}
