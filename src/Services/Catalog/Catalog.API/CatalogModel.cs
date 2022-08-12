using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API
{
    public class CatalogModel
    {
        public string Name { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }


    }
}
