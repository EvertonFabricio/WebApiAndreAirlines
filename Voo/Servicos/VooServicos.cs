using System.Collections.Generic;
using Voo.Util;
using Model;
using MongoDB.Driver;
using System.Threading.Tasks;
using Consultas;

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

        public async Task<Model.Voo> CreateAsync(Model.Voo voo)
        {
            var retornoOrigem = await Origem.AeroportoOrigem(voo.Origem.Iata.ToUpper());
            if (retornoOrigem != null)
            {
                voo.Origem.Nome = retornoOrigem.Nome;
                voo.Origem.Endereco = retornoOrigem.Endereco;
                voo.Origem.Id = retornoOrigem.Id;
            }
            var retornoDestino = await Destino.AeroportoDestino(voo.Destino.Iata.ToUpper());
            if (retornoDestino != null)
            {
                voo.Destino.Nome = retornoDestino.Nome;
                voo.Destino.Endereco = retornoDestino.Endereco;
                voo.Destino.Id = retornoDestino.Id;
            } 
            var retornoAeronave = await BuscaAeronave.GetAeronave(voo.Aeronave.Registro.ToUpper());
            if (retornoAeronave != null)
            {
                voo.Aeronave.Nome = retornoAeronave.Nome;
                voo.Aeronave.Capacidade = retornoAeronave.Capacidade;
                voo.Aeronave.Id = retornoAeronave.Id;
                
            }

            _voo.InsertOne(voo);
            return voo;
        }

        public void Update(string id, Model.Voo voo) =>
            _voo.ReplaceOne(voo => voo.Id == id, voo);


        public void Remove(string id) =>
            _voo.DeleteOne(voo => voo.Id == id);

    }
}
