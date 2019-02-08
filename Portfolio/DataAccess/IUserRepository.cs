using System.Threading;
using System.Threading.Tasks;

using Portfolio.Domain;

namespace Portfolio.DataAccess
{
    public interface IUserRepository : IRepository<string, User>
    {
        Task<bool> Upsert(User user, CancellationToken cancellationToken = default(CancellationToken));
    }
}
