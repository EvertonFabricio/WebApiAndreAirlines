using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Usuario.Util;

namespace Usuario.Servicos
{
    public class UsuarioServicos
    {
        private readonly IMongoCollection<Model.Usuario> _usuario;

        public UsuarioServicos(IUsuarioDatabase settings)
        {
            var usuario = new MongoClient(settings.ConnectionString);
            var database = usuario.GetDatabase(settings.DatabaseName);
            _usuario = database.GetCollection<Model.Usuario>(settings.UsuarioCollectionName);
        }

        public List<Model.Usuario> Get() =>
            _usuario.Find(usuario => true).ToList();

        public Model.Usuario Get(string id) =>
            _usuario.Find(usuario => usuario.Id == id).FirstOrDefault();

        public Model.Usuario Create(Model.Usuario usuario)
        {
            _usuario.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Model.Usuario usuario) =>
            _usuario.ReplaceOne(usuario => usuario.Id == id, usuario);


        public void Remove(string id) =>
            _usuario.DeleteOne(usuario => usuario.Id == id);
    }
}
