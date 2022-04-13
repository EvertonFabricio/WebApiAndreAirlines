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
    public class BuscaVoo
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Voo> Voo(string Numero)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44390/api/Voo/" + Numero);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var voo = JsonConvert.DeserializeObject<Voo>(corpoResposta);

                return voo;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
