using System.Threading;
using System.Threading.Tasks;

using Portfolio.Domain;

namespace Portfolio.DataAccess
{
    public interface IRepository<in TKey, TEntity> where TEntity : IEntity<TKey>
    {
        Task<TEntity> Get(TKey id, CancellationToken cancellationToken = default(CancellationToken));

        Task Add(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task Save(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task Delete(TKey id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
