using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Aeronave
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }

    }
}
