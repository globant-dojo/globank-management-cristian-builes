using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BancoBuiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteServicio _clienteServicio;

        public ClientesController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        [HttpGet]
        [Route("ObtenerClientes")]
        [ActionName("ObtenerClientes")]
        public IEnumerable<Cliente> ObtenerClientes()
        {
            return _clienteServicio.ObtenerClientes();
        }

        [HttpGet]
        [Route("ObtenerCliente")]
        [ActionName("ObtenerCliente")]
        public Cliente ObtenerCliente(int id)
        {
            return _clienteServicio.ObtenerCliente(id);
        }

        [HttpPost]
        [Route("Crear")]
        [ActionName("Crear")]
        public void Crear([FromBody] Cliente cliente)
        {
            _clienteServicio.CrearCliente(cliente);
        }

        [HttpPut]
        [Route("Actualizar")]
        [ActionName("Actualizar")]
        public void Actualizar([FromBody] Cliente cliente)
        {
            _clienteServicio.ActualizarCliente(cliente);
        }

        [HttpDelete]
        [Route("Borrar")]
        [ActionName("Borrar")]
        public void Borrar([FromBody] Cliente cliente)
        {
            _clienteServicio.BorrarCliente(cliente.Id.GetValueOrDefault());
        }
    }
}
