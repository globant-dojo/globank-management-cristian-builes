using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services;
using Moq;
using NUnit.Framework;

namespace BancoBuilesTest
{
    [TestFixture]
    public class MovimientoCreditoServicioTest
    {
        private MovimientoCreditoServicio _movimiento;

        [SetUp]
        public void Init()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var movimientos = new Mock<IMovimientoRepository>();
            movimientos.Setup(m => m.Add(null));
            unitOfWork.Setup(m => m.Movimientos).Returns(movimientos.Object);
            _movimiento = new MovimientoCreditoServicio(unitOfWork.Object);
        }

        [Test]
        public void RealizarMovimiento_SumaValorAlSaldo()
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Saldo = 10000;
            Movimiento movimiento = new Movimiento();
            movimiento.Valor = 10000;

            _movimiento.RealizarMovimiento(cuenta, movimiento);

            Assert.IsTrue(cuenta.Saldo == 20000);
            Assert.IsTrue(movimiento.Saldo == 20000);
        }
    }
}
