using MongoDB.Driver;
using Model;
using Classe.Util;
using System.Collections.Generic;

namespace Classe.Servicos
{
    public class ClasseServicos
    {
        private readonly IMongoCollection<Model.Classe> _classe;

        public ClasseServicos(IClasseDataBase settings)
        {
            var classe = new MongoClient(settings.ConnectionString);
            var database = classe.GetDatabase(settings.DatabaseName);
            _classe = database.GetCollection<Model.Classe>(settings.ClasseCollectionName);
        }

        public List<Model.Classe> Get() =>
            _classe.Find(classe => true).ToList();

        public Model.Classe Get(string codigo) =>
            _classe.Find(classe => classe.Codigo == codigo).FirstOrDefault();

      
        public Model.Classe Create(Model.Classe classe)
        {
            _classe.InsertOne(classe);
            return classe;
        }

        public void Update(string codigo, Model.Classe upClasse) =>
            _classe.ReplaceOne(classe => classe.Codigo == codigo, upClasse);

        public void Remove(string id) =>
            _classe.DeleteOne(classe => classe.Id == id);
    }
}
