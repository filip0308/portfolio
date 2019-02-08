using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace Portfolio.DataAccess
{
    public static class MongoExtensions
    {
        public static async Task<bool> SafeUpsert<TDocument>(
            this IMongoCollection<TDocument> collection,
            Expression<Func<TDocument, bool>> precondition,
            TDocument newVersion,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                return
                (await collection.ReplaceOneAsync(
                        precondition,
                        newVersion,
                        new UpdateOptions { IsUpsert = true },
                        cancellationToken)
                    .ConfigureAwait(false)).IsAcknowledged;
            }
            catch (MongoWriteException)
            {
                return false;
            }
        }
    }
}
