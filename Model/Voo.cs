using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Voo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string NumeroVoo { get; set; }
        public Aeroporto Origem { get; set; }
        public Aeroporto Destino { get; set; }
        public Aeronave Aeronave { get; set; }
        public decimal PrecoBase { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataEmbarque { get; set; }

        public DateTime DataDesembarque { get; set; }

    }
}
