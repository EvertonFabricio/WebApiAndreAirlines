using System.Collections.Generic;
using Reserva.Util;
using Model;
using MongoDB.Driver;

namespace Reserva.Servicos
{
    public class ReservaServicos
    {
        private readonly IMongoCollection<Model.Reserva> _reserva;

        public ReservaServicos(IReservaDatabase settings)
        {
            var reserva = new MongoClient(settings.ConnectionString);
            var database = reserva.GetDatabase(settings.DatabaseName);
            _reserva = database.GetCollection<Model.Reserva>(settings.ReservaCollectionName);
        }

        public List<Model.Reserva> Get() =>
            _reserva.Find(reserva => true).ToList();

        public Model.Reserva Get(string id) =>
            _reserva.Find<Model.Reserva>(reserva => reserva. Id == id).FirstOrDefault();

        public Model.Reserva Create(Model.Reserva reserva)
        {
            _reserva.InsertOne(reserva);
            return reserva;
        }

        public void Update(string id, Model.Reserva reserva) =>
            _reserva.ReplaceOne(reserva => reserva.Id == id, reserva);


        public void Remove(string id) =>
            _reserva.DeleteOne(reserva => reserva.Id == id);

    }
}
