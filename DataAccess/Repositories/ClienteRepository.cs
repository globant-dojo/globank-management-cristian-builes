using Common.Constants;
using Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace DataAccess.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
