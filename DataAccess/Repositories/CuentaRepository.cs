using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class CuentaRepository : GenericRepository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
