using System.Collections.Generic;
using Aeronave.Util;
using Model;
using MongoDB.Driver;


namespace Aeronave.Servicos
{
    public class AeronaveServicos
    {
       
            private readonly IMongoCollection<Model.Aeronave> _aeronave;

            public AeronaveServicos(IAeronaveDatabase settings)
            {
                var aeronave = new MongoClient(settings.ConnectionString);
                var database = aeronave.GetDatabase(settings.DatabaseName);
            _aeronave = database.GetCollection<Model.Aeronave>(settings.AeronaveCollectionName);
            }

            public List<Model.Aeronave> Get() =>
                _aeronave.Find(aeronave => true).ToList();

            public Model.Aeronave Get(string id) =>
                _aeronave.Find(aeronave => aeronave.Id == id).FirstOrDefault();

            public Model.Aeronave Create(Model.Aeronave newAeronave)
            {
            _aeronave.InsertOne(newAeronave);
                return newAeronave;
            }

            public void Update(string id, Model.Aeronave upAeronave) =>
                _aeronave.ReplaceOne(aeronave => aeronave.Id == id, upAeronave);

            public void Remove(string id) =>
                _aeronave.DeleteOne(aeronave => aeronave.Id == id);
        
    }
}
