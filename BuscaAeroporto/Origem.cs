using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Consultas
{
    public class Origem
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Aeroporto> AeroportoOrigem(string Iata)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44387/api/Aeroporto/"+Iata);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var origem = JsonConvert.DeserializeObject<Aeroporto>(corpoResposta);

                return origem;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
