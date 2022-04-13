using System.Collections.Generic;
using System.Threading.Tasks;
using Consultas;
using MongoDB.Driver;
using Reserva.Util;

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

        public async Task<Model.Reserva> CreateAsync(Model.Reserva reserva)
        {
            var retornoVoo = await BuscaVoo.Voo(reserva.Voo.NumeroVoo);
            reserva.Voo.Origem = retornoVoo.Origem;
            reserva.Voo.Destino = retornoVoo.Destino;

            var retornoPassageiro = await BuscaPassageiro.Passageiro(reserva.Passageiro.Cpf);
            reserva.Passageiro = retornoPassageiro;

            var retornoClasse = await BuscaClasse.Classe(reserva.Classe.Codigo);
            reserva.Classe = retornoClasse;


            reserva.ValorTotal = retornoVoo.PrecoBase * retornoClasse.VariacaoValorBase + retornoVoo.PrecoBase;
            reserva.ValorTotal = reserva.ValorTotal - (reserva.ValorTotal * reserva.PorcentagemDesconto/100);

           

            _reserva.InsertOne(reserva);
            return reserva;
        }

        public void Update(string id, Model.Reserva reserva) =>
            _reserva.ReplaceOne(reserva => reserva.Id == id, reserva);


        public void Remove(string id) =>
            _reserva.DeleteOne(reserva => reserva.Id == id);

    }
}
