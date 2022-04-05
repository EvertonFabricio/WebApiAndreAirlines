using System.Collections.Generic;
using PrecoBase.Util;
using Model;
using MongoDB.Driver;

namespace PrecoBase.Services
{
    public class PrecoBaseServicos
    {
        private readonly IMongoCollection<Model.PrecoBase> _precobase;

        public PrecoBaseServicos(IPrecoBaseDatabase settings)
        {
            var precobase = new MongoClient(settings.ConnectionString);
            var database = precobase.GetDatabase(settings.DatabaseName);
            _precobase = database.GetCollection<Model.PrecoBase>(settings.PrecoBaseCollectionName);
        }

        public List<Model.PrecoBase> Get() =>
            _precobase.Find(precobase => true).ToList();

        public Model.PrecoBase Get(string id) =>
            _precobase.Find<Model.PrecoBase>(precobase => precobase.Id == id).FirstOrDefault();

        public Model.PrecoBase Create(Model.PrecoBase precobase)
        {
            _precobase.InsertOne(precobase
                );
            return precobase;
        }

        public void Update(string id, Model.PrecoBase precobase) =>
            _precobase.ReplaceOne(precobase => precobase.Id == id, precobase);


        public void Remove(string id) =>
            _precobase.DeleteOne(precobase => precobase.Id == id);

    }
}
