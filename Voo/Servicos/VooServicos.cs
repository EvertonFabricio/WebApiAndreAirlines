using System.Collections.Generic;
using Voo.Util;
using Model;
using MongoDB.Driver;

namespace Voo.Servicos
{
    public class VooServicos
    {
        private readonly IMongoCollection<Model.Voo> _voo;

        public VooServicos(IVooDatabase settings)
        {
            var voo = new MongoClient(settings.ConnectionString);
            var database = voo.GetDatabase(settings.DatabaseName);
            _voo = database.GetCollection<Model.Voo>(settings.VooCollectionName);
        }

        public List<Model.Voo> Get() =>
            _voo.Find(voo => true).ToList();

        public Model.Voo Get(string id) =>
            _voo.Find<Model.Voo>(voo => voo.Id == id).FirstOrDefault();

        public Model.Voo Create(Model.Voo voo)
        {
            _voo.InsertOne(voo);
            return voo;
        }

        public void Update(string id, Model.Voo voo) =>
            _voo.ReplaceOne(voo => voo.Id == id, voo);


        public void Remove(string id) =>
            _voo.DeleteOne(voo => voo.Id == id);

    }
}
