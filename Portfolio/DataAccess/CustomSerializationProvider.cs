using System;
using System.Collections.Generic;

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Portfolio.DataAccess
{
    public class CustomSerializationProvider : IBsonSerializationProvider
    {
        private readonly Dictionary<Type, IBsonSerializer> serialiserFactories = new Dictionary<Type, IBsonSerializer>
        {
            [typeof(Guid)] = new GuidSerializer(),
            [typeof(DateTime)] = new DateTimeSerializer(DateTimeKind.Local)
        };

        public IBsonSerializer GetSerializer(Type type)
        {
            return this.serialiserFactories.ContainsKey(type) ? this.serialiserFactories[type] : null;
        }
    }
}
