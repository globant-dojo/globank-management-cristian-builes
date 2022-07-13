using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoBuiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController
    {
        private readonly ICuentaServicio _cuentaServicio;

        public CuentasController(ICuentaServicio cuentaServicio)
        {
            _cuentaServicio = cuentaServicio;
        }

        [HttpGet]
        [Route("ObtenerCuentas")]
        [ActionName("ObtenerCuentas")]
        public IEnumerable<Cuenta> ObtenerCuentas()
        {
            return _cuentaServicio.ObtenerCuentas();
        }

        [HttpGet]
        [Route("ObtenerCuenta")]
        [ActionName("ObtenerCuenta")]
        public Cuenta ObtenerCliente(int id)
        {
            return _cuentaServicio.ObtenerCuenta(id);
        }

        [HttpPost]
        [Route("Crear")]
        [ActionName("Crear")]
        public void Crear([FromBody] Cuenta cuenta)
        {
            _cuentaServicio.CrearCuenta(cuenta);
        }

        [HttpPut]
        [Route("Actualizar")]
        [ActionName("Actualizar")]
        public void Actualizar([FromBody] Cuenta cuenta)
        {
            _cuentaServicio.ActualizarCuenta(cuenta);
        }

        [HttpDelete]
        [Route("Borrar")]
        [ActionName("Borrar")]
        public void Borrar([FromBody] Cuenta cuenta)
        {
            _cuentaServicio.BorrarCuenta(cuenta.Id.GetValueOrDefault());
        }
    }
}
