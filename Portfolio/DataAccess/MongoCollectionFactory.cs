using MongoDB.Driver;

using Portfolio.Domain;
using System.Security.Authentication;

namespace Portfolio.DataAccess
{
    public class MongoCollectionFactory
    {
        public IMongoCollection<TEntity> Create<TEntity>(string collectionName) where TEntity : IEntity
        {
            string connectionString = @"mongodb://dev-portfolio:s2yFRgkgO9Up7cdXFN6FuZjnuh5seDyT1Zc8ul2OGjJ7SxpCCF35bC1kPzTbqFk1iCN3JfqXPfFlIHC271lIqw==@dev-portfolio.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            return new MongoClient(settings)
            .GetDatabase("Warehouse")
            .GetCollection<TEntity>(collectionName);
        }
    }
}
