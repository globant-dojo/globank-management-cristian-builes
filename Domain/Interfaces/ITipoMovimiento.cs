using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITipoMovimiento
    {
        void RealizarMovimiento(Cuenta cuenta, Movimiento movimiento);
    }
}
