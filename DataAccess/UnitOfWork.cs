using DataAccess.Repositories;
using Domain.Interfaces.Repositories;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IClienteRepository Clientes { private set; get; }

        public ICuentaRepository Cuentas { private set; get; }

        public IMovimientoRepository Movimientos { private set; get; }

        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Clientes = new ClienteRepository(_context);
            Cuentas = new CuentaRepository(_context);
            Movimientos = new MovimientoRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
