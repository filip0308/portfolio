using System.Threading;
using System.Threading.Tasks;

using Portfolio.Domain;

namespace Portfolio.DataAccess
{
    public class UserRepository : MongoRepository<string, User>, IUserRepository
    {
        public UserRepository(MongoCollectionFactory collectionFactory)
            : base(collectionFactory.Create<User>("Users"))
        {
        }

        public async Task<bool> Upsert(User user, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Collection.SafeUpsert(d => d.Id == user.Id, user, cancellationToken);
        }
    }
}
