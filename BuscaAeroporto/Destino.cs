using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Consultas
{
    public class Destino
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Aeroporto> AeroportoDestino(string Iata)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44387/api/Aeroporto/" + Iata);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var destino = JsonConvert.DeserializeObject<Aeroporto>(corpoResposta);

                return destino;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
