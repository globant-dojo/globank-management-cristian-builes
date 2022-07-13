using Common.Constants;
using Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class CuentaServicio : ICuentaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public CuentaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ActualizarCuenta(Cuenta cuenta)
        {
            Cuenta cuentaActualizar = _unitOfWork.Cuentas.GetById(cuenta.Id.Value);

            if (cuentaActualizar == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.RegistroInexistente, Mensaje.RegistroInexistente);
            }

            if (cuenta.NumeroCuenta != cuentaActualizar.NumeroCuenta &&
                _unitOfWork.Cuentas.Find(c => c.NumeroCuenta == cuenta.NumeroCuenta).Any())
            { // No se puede cambiar el número de cuenta por la de una cuenta existente
                throw new BancoBuilesException(CodigoExcepcion.NumeroCuentaUsado, Mensaje.NumeroCuentaUsado);
            }

            if (cuenta.IdCliente != null && cuenta.IdCliente != cuentaActualizar.IdCliente)
            {
                throw new BancoBuilesException(CodigoExcepcion.ClienteCuentaUnico, Mensaje.ClienteCuentaUnico);
            }

            cuentaActualizar.NumeroCuenta = cuenta.NumeroCuenta ?? cuentaActualizar.NumeroCuenta;
            cuentaActualizar.Saldo = cuenta.Saldo ?? cuentaActualizar.Saldo;
            cuentaActualizar.EstadoId = cuenta.EstadoId ?? cuentaActualizar.EstadoId;
            cuentaActualizar.TipoCuentaId = cuenta.TipoCuentaId ?? cuentaActualizar.TipoCuentaId;
            cuentaActualizar.IdCliente = cuenta.IdCliente ?? cuentaActualizar.IdCliente;           
            _unitOfWork.Complete();
        }

        public void BorrarCuenta(int Id)
        {
            Cuenta cuenta = _unitOfWork.Cuentas.GetById(Id);

            if (cuenta == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.RegistroInexistente, Mensaje.RegistroInexistente);
            }

            _unitOfWork.Cuentas.Remove(cuenta);
            _unitOfWork.Complete();
        }

        public void CrearCuenta(Cuenta cuenta)
        {
            if (cuenta.Id != null)
            {
                throw new BancoBuilesException(CodigoExcepcion.Id, Mensaje.Id);
            }

            bool existe = _unitOfWork.Cuentas.Find(c => c.NumeroCuenta == cuenta.NumeroCuenta).Any();

            if (existe)
            {
                throw new BancoBuilesException(CodigoExcepcion.NumeroCuentaUsado, Mensaje.NumeroCuentaUsado);
            }

            Cliente cliente = _unitOfWork.Clientes.GetById(cuenta.IdCliente.GetValueOrDefault());

            if (cliente == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.ClienteNoExiste, Mensaje.ClienteNoExiste);
            }

            _unitOfWork.Cuentas.Add(cuenta);
            _unitOfWork.Complete();
        }

        public IEnumerable<Cuenta> ObtenerCuentas()
        {
            return _unitOfWork.Cuentas.GetAll();
        }

        public Cuenta ObtenerCuenta(int Id)
        {
            return _unitOfWork.Cuentas.GetById(Id);
        }
    }
}
