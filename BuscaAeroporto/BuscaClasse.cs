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
    public class BuscaClasse
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Classe> Classe(string Codigo)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44389/api/Classe/" + Codigo);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var aeronave = JsonConvert.DeserializeObject<Classe>(corpoResposta);

                return aeronave;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
