using Common.Constants;
using Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public class ClienteServicio : IClienteServicio
    {
        private IUnitOfWork _unitOfWork;

        public ClienteServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ActualizarCliente(Cliente cliente)
        {
            Cliente clienteActualizar = _unitOfWork.Clientes.GetById(cliente.Id.Value);

            if (clienteActualizar == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.RegistroInexistente, Mensaje.RegistroInexistente);
            }

            clienteActualizar.Nombre = cliente.Nombre ?? clienteActualizar.Nombre;
            clienteActualizar.Identificacion = cliente.Identificacion ?? clienteActualizar.Identificacion;
            clienteActualizar.Clave = cliente.Clave ?? clienteActualizar.Clave;
            clienteActualizar.Direccion = cliente.Direccion ?? clienteActualizar.Direccion;
            clienteActualizar.Edad = cliente.Edad ?? clienteActualizar.Edad;
            clienteActualizar.EstadoId = cliente.EstadoId ?? clienteActualizar.EstadoId;
            clienteActualizar.GeneroId = cliente.GeneroId ?? clienteActualizar.GeneroId;
            clienteActualizar.Telefono = cliente.Telefono ?? clienteActualizar.Telefono;
            _unitOfWork.Complete();
        }

        public void BorrarCliente(int Id)
        {
            Cliente cliente = _unitOfWork.Clientes.GetById(Id);

            if (cliente == null)
            {
                throw new BancoBuilesException(CodigoExcepcion.RegistroInexistente, Mensaje.RegistroInexistente);
            }

            _unitOfWork.Clientes.Remove(cliente);
            _unitOfWork.Complete();
        }

        public void CrearCliente(Cliente cliente)
        {
            if (cliente.Id != null)
            {
                throw new BancoBuilesException(CodigoExcepcion.Id, Mensaje.Id);
            }

            _unitOfWork.Clientes.Add(cliente);
            _unitOfWork.Complete();
        }

        public Cliente ObtenerCliente(int Id)
        {
            return _unitOfWork.Clientes.GetById(Id);
        }

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return _unitOfWork.Clientes.GetAll();
        }
    }
}
