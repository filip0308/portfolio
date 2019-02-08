using System.Threading;
using System.Threading.Tasks;

using Portfolio.Domain;

using MongoDB.Driver;

namespace Portfolio.DataAccess
{
    public abstract class MongoRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        protected MongoRepository(IMongoCollection<TEntity> collection)
        {
            this.Collection = collection;
        }

        protected IMongoCollection<TEntity> Collection { get; }

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            => await this.Collection.InsertOneAsync(entity, null, cancellationToken);

        public virtual async Task Delete(TKey id, CancellationToken cancellationToken = default(CancellationToken))
            => await this.Collection.DeleteOneAsync(this.CreateIdentityFilter(id), cancellationToken);

        public virtual async Task<TEntity> Get(TKey id, CancellationToken cancellationToken = default(CancellationToken))
            => await this.Collection.Find(this.CreateIdentityFilter(id)).SingleOrDefaultAsync(cancellationToken);

        public virtual async Task Save(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            =>
                await
                    this.Collection.ReplaceOneAsync(
                        this.CreateIdentityFilter(entity.Id),
                        entity,
                        new UpdateOptions { IsUpsert = true },
                        cancellationToken);

        protected FilterDefinition<TEntity> CreateIdentityFilter(TKey id)
            => Builders<TEntity>.Filter.Eq(nameof(IEntity<TKey>.Id), id);
    }
}
