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

        public Model.Passageiro Get(string CPF) =>
            _passageiro.Find(passageiro => passageiro.Cpf == CPF.Replace(".", "").Replace("-", "")).FirstOrDefault();

        public Model.Passageiro Create(Model.Passageiro passageiro)
        {
            passageiro.Cpf = passageiro.Cpf.Replace(".", "").Replace("-","");
            _passageiro.InsertOne(passageiro);
            return passageiro;
        }

        public Model.Passageiro ChecarCpf(string CPF) =>
            _passageiro.Find(passageiro => passageiro.Cpf == CPF).FirstOrDefault();

        public void Update(string id, Model.Passageiro passageiro) =>        
            _passageiro.ReplaceOne(passageiro => passageiro.Id == id, passageiro);
        

        public void Remove(string id) =>
            _passageiro.DeleteOne(passageiro => passageiro.Id == id);

        public bool ValidarCpf(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;
            tempCpf = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }

    }
}
