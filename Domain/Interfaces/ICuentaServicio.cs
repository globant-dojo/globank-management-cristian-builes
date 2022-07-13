using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICuentaServicio
    {
        IEnumerable<Cuenta> ObtenerCuentas();
        Cuenta ObtenerCuenta(int Id);
        void CrearCuenta(Cuenta cuenta);
        void ActualizarCuenta(Cuenta cuenta);
        void BorrarCuenta(int Id);
    }
}
