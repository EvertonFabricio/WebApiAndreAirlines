using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Reserva
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Voo Voo { get; set; }
        public Passageiro Passageiro { get; set; }
        public PrecoBase PrecoBase { get; set; }
        public Classe Classe { get; set; }
        public decimal PorcentagemDesconto { get; set; }
        public decimal ValorTotal { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }

    }
}
