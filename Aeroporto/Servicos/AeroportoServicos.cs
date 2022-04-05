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
            _aeroporto.Find(airport => true).ToList();

        public Model.Aeroporto Get(string id) =>
            _aeroporto.Find<Model.Aeroporto>(aircraft => aircraft.Id == id).FirstOrDefault();

        public Model.Aeroporto Create(Model.Aeroporto aeroportp)
        {
            _aeroporto.InsertOne(aeroportp);
            return aeroportp;
        }

        public void Update(string id, Model.Aeroporto upAirport)
        {
            _aeroporto.ReplaceOne(airport => airport.Id == id, upAirport);
        }

        public void Remove(string id) =>
            _aeroporto.DeleteOne(airport => airport.Id == id);


    }
}
