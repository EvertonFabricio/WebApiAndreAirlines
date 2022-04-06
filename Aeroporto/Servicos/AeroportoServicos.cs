using Aeroporto.Util;
using MongoDB.Driver;
using Model;
using System.Collections.Generic;

namespace Aeroporto.Servicos
{
    public class AeroportoServicos
    {
        private readonly IMongoCollection<Model.Aeroporto> _aeroporto;

        public AeroportoServicos(IAeroportoDatabase settings)
        {
            var aeroporto = new MongoClient(settings.ConnectionString);
            var database = aeroporto.GetDatabase(settings.DatabaseName);
            _aeroporto = database.GetCollection<Model.Aeroporto>(settings.AeroportoCollectionName);
        }

        public List<Model.Aeroporto> Get() =>
            _aeroporto.Find(aeroporto => true).ToList();

        public Model.Aeroporto Get(string id) =>
            _aeroporto.Find(aeroporto => aeroporto.Id == id).FirstOrDefault();

        public Model.Aeroporto Create(Model.Aeroporto aeroporto)
        {
            _aeroporto.InsertOne(aeroporto);
            return aeroporto;
        }
        public Model.Aeroporto ChecarIata(string Iata) =>
           _aeroporto.Find(aeroporto => aeroporto.Iata == Iata).FirstOrDefault();

        public void Update(string id, Model.Aeroporto upAeroporto)
        {
            _aeroporto.ReplaceOne(aeroporto => aeroporto.Id == id, upAeroporto);
        }

        public void Remove(string id) =>
            _aeroporto.DeleteOne(aeroporto => aeroporto.Id == id);


    }
}
