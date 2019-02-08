using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace Portfolio.DataAccess
{
    public class MongoMappingConfiguration
    {
        public static void Configure(Func<Type, bool> domainConventionFilter)
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var pack = new ConventionPack { new CamelCaseElementNameConvention(), new NamedIdMemberConvention("Id", "id") };

            ConventionRegistry.Register(
                "Domain convention",
                pack,
                domainConventionFilter);

            BsonSerializer.RegisterSerializationProvider(new CustomSerializationProvider());
        }
    }
}
