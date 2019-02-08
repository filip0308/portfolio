using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using Portfolio.Domain;

namespace Portfolio.DataAccess
{
    public class ProductRepository : MongoRepository<string, Product>, IProductRepository
    {
        public ProductRepository(MongoCollectionFactory collectionFactory)
            : base(collectionFactory.Create<Product>("Products"))
        {
        }

        public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default(CancellationToken))
        {
            return (await this.Collection.AsQueryable().ToListAsync()).ToArray();
        }

        public async Task<bool> Upsert(Product product, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Collection.SafeUpsert(d => d.Id == product.Id, product, cancellationToken);
        }
    }
}
