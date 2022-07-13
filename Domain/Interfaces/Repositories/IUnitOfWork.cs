namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        ICuentaRepository Cuentas { get; }
        IMovimientoRepository Movimientos { get; }
        int Complete();
    }
}
