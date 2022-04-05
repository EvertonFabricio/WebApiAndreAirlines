using System.Collections.Generic;
using Model;
using MongoDB.Driver;
using Passageiro.Util;


namespace Passageiro.Servicos
{
    public class PassageiroServicos
    {
        private readonly IMongoCollection<Model.Passageiro> _passageiro;

        public PassageiroServicos(IPassageiroDatabase settings)
        {
            var passageiro = new MongoClient(settings.ConnectionString);
            var database = passageiro.GetDatabase(settings.DatabaseName);
            _passageiro = database.GetCollection<Model.Passageiro>(settings.PassageiroCollectionName);
        }

        public List<Model.Passageiro> Get() =>
            _passageiro.Find(passageiro => true).ToList();

        public Model.Passageiro Get(string id) =>
            _passageiro.Find<Model.Passageiro>(passageiro => passageiro.Id == id).FirstOrDefault();

        public Model.Passageiro Create(Model.Passageiro passageiro)
        {
            _passageiro.InsertOne(passageiro);
            return passageiro;
        }

        public void Update(string id, Model.Passageiro passageiro) =>        
            _passageiro.ReplaceOne(passageiro => passageiro.Id == id, passageiro);
        

        public void Remove(string id) =>
            _passageiro.DeleteOne(passageiro => passageiro.Id == id);
        
    }
}
