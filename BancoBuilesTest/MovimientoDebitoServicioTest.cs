using Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services;
using Moq;
using NUnit.Framework;

namespace BancoBuilesTest
{
    [TestFixture]
    public class MovimientoDebitoServicioTest
    {
        private MovimientoDebitoServicio _movimiento;

        [SetUp]
        public void Init()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var movimientos = new Mock<IMovimientoRepository>();
            movimientos.Setup(m => m.Add(null));
            unitOfWork.Setup(m => m.Movimientos).Returns(movimientos.Object);
            _movimiento = new MovimientoDebitoServicio(unitOfWork.Object);
        }

        [Test]
        public void RealizarMovimiento_ValorIgualASaldo_SaldoEnZero() 
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Saldo = 10000;
            Movimiento movimiento = new Movimiento();
            movimiento.Valor = 10000;

            _movimiento.RealizarMovimiento(cuenta, movimiento);

            Assert.IsTrue(cuenta.Saldo == 0);
            Assert.IsTrue(movimiento.Saldo == 0);
        }

        [Test]
        public void RealizarMovimiento_ValorMenorASaldo_SaldoPositivo()
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Saldo = 20000;
            Movimiento movimiento = new Movimiento();
            movimiento.Valor = 10000;

            _movimiento.RealizarMovimiento(cuenta, movimiento);

            Assert.IsTrue(cuenta.Saldo == 10000);
            Assert.IsTrue(movimiento.Saldo == 10000);
        }

        [Test]
        public void RealizarMovimiento_ValorMayorASaldo_Excepcion()
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Saldo = 10000;
            Movimiento movimiento = new Movimiento();
            movimiento.Valor = 20000;
            
            Assert.Throws<BancoBuilesException>(() => _movimiento.RealizarMovimiento(cuenta, movimiento));
        }
    }
}
