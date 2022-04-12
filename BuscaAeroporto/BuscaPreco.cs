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
    public class BuscaPreco
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<PrecoBase> GetAeronave(string Registro)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44338/api/PrecoBase/" + Registro);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var preco = JsonConvert.DeserializeObject<PrecoBase>(corpoResposta);

                return preco;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
