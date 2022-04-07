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

        public Model.Aeronave Get(string registro) =>
            _aeronave.Find(aeronave => aeronave.Registro == registro.ToUpper()).FirstOrDefault();

        public Model.Aeronave ChecarRegistro(string registro) =>
            _aeronave.Find(aeronave => aeronave.Registro == registro.ToUpper()).FirstOrDefault();

        public Model.Aeronave Create(Model.Aeronave aeronave)
        {
            aeronave.Registro = aeronave.Registro.ToUpper();
            _aeronave.InsertOne(aeronave);
            return aeronave;
        }

        public void Update(string id, Model.Aeronave upAeronave) =>
            _aeronave.ReplaceOne(aeronave => aeronave.Id == id, upAeronave);

        public void Remove(string id) =>
            _aeronave.DeleteOne(aeronave => aeronave.Id == id);

    }
}
