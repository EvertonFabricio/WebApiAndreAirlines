using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Classe
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal VariacaoValorBase { get; set; }

    }
}