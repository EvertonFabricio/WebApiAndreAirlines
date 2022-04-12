using System.Net.Http;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Consultas
{
    public class BuscaAeronave
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Aeronave> GetAeronave(string Registro)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44338/api/Aeronave/" + Registro);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var aeronave = JsonConvert.DeserializeObject<Aeronave>(corpoResposta);

                return aeronave;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
