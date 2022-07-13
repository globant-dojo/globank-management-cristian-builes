using Common.Constants;
using Common.Exceptions;
using Domain.Enum;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Services;

namespace Domain.Static
{
    public static class FabricaTipoMovimiento
    {
        public static ITipoMovimiento ObtenerInstancia(IUnitOfWork unitOfWork, int tipoMovimiento) 
        {
            switch ((int)tipoMovimiento)
            {
                case (int)TipoMovimiento.Credito:
                    return new MovimientoCreditoServicio(unitOfWork);
                case (int)TipoMovimiento.Debito:
                    return new MovimientoDebitoServicio(unitOfWork);
                default:
                    throw new BancoBuilesException(CodigoExcepcion.TipoMovimientoNoSoportado, Mensaje.TipoMovimientoNoSoportado);
            }
        }
    }
}
