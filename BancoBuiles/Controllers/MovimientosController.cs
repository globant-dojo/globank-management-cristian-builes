using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BancoBuiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController
    {
        private readonly IMovimientoServicio _movimientoServicio;

        public MovimientosController(IMovimientoServicio movimientoServicio)
        {
            _movimientoServicio = movimientoServicio;
        }

        [HttpGet]
        [Route("ReportePorCliente")]
        [ActionName("ReportePorCliente")]
        public IEnumerable<Movimiento> ReportePorCliente(int clienteId, DateTime fechaInicial, DateTime fechaFinal)
        {
            return _movimientoServicio.ObtenerMovimientosPorCliente(clienteId, fechaInicial, fechaFinal);
        }

        [HttpGet]
        [Route("ReportePorCuenta")]
        [ActionName("ReportePorCuenta")]
        public IEnumerable<Movimiento> ReportePorCuenta(int cuentaId, DateTime fechaInicial, DateTime fechaFinal)
        {
            return _movimientoServicio.ObtenerMovimientosPorCuenta(cuentaId, fechaInicial, fechaFinal);
        }

        [HttpGet]
        [Route("ObtenerMovimientos")]
        [ActionName("ObtenerMovimientos")]
        public IEnumerable<Movimiento> ObtenerMovimientos()
        {
            return _movimientoServicio.ObtenerMovimientos();
        }

        [HttpGet]
        [Route("ObtenerMovimiento")]
        [ActionName("ObtenerMovimiento")]
        public Movimiento ObtenerMovimiento(int id)
        {
            return _movimientoServicio.ObtenerMovimiento(id);
        }

        [HttpPost]
        [Route("Crear")]
        [ActionName("Crear")]
        public void Crear([FromBody] Movimiento movimiento)
        {
            _movimientoServicio.Crear(movimiento);
        }

        [HttpPut]
        [Route("Actualizar")]
        [ActionName("Actualizar")]
        public void Actualizar([FromBody] Movimiento movimiento)
        {
            _movimientoServicio.Actualizar(movimiento);
        }

        [HttpDelete]
        [Route("Borrar")]
        [ActionName("Borrar")]
        public void Borrar([FromBody] Movimiento movimiento)
        {
            _movimientoServicio.Borrar(movimiento.Id.GetValueOrDefault());
        }
    }
}
