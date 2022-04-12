using System.Collections.Generic;
using System.Threading.Tasks;
using Consultas;
using MongoDB.Driver;
using PrecoBase.Util;

namespace PrecoBase.Servicos
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
            _precobase.Find(precobase => precobase.Id == id).FirstOrDefault();



        public async Task<Model.PrecoBase> CreateAsync(Model.PrecoBase precobase)
        {

            var retornoOrigem = await Origem.AeroportoOrigem(precobase.Origem.Iata.ToUpper());
            precobase.Origem.Nome = retornoOrigem.Nome;
            precobase.Origem.Endereco = retornoOrigem.Endereco;
            precobase.Origem.Id = retornoOrigem.Id;

            var retornoDestino = await Destino.AeroportoDestino(precobase.Destino.Iata.ToUpper());
            precobase.Destino.Nome = retornoDestino.Nome;
            precobase.Destino.Endereco = retornoDestino.Endereco;
            precobase.Destino.Id = retornoDestino.Id;

            _precobase.InsertOne(precobase);
            return precobase;
        }

        public void Update(string id, Model.PrecoBase precobase) =>
            _precobase.ReplaceOne(precobase => precobase.Id == id, precobase);


        public void Remove(string id) =>
            _precobase.DeleteOne(precobase => precobase.Id == id);



    }
}
