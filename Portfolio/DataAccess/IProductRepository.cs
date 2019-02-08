using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Portfolio.Domain;

namespace Portfolio.DataAccess
{
    public interface IProductRepository : IRepository<string, Product>
    {
        Task<bool> Upsert(Product product, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default(CancellationToken));
    }
}
