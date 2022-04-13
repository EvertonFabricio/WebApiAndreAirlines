using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Consultas
{
    public class BuscaPassageiro
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Passageiro> Passageiro(string CPF)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44361/api/Passageiro/CPF?CPF=" + CPF);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var passageiro = JsonConvert.DeserializeObject<Passageiro>(corpoResposta);

                return passageiro;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
