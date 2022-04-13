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
    public class BuscaUsuario
    {
        static readonly HttpClient client = new HttpClient();


        public static async Task<Usuario> Usuario(string username, string password)
        {
            try
            {
                HttpResponseMessage respostaAPI = await client.GetAsync("https://localhost:44376/api/Usuario/" + username +","+ password);
                respostaAPI.EnsureSuccessStatusCode();
                string corpoResposta = await respostaAPI.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<Usuario>(corpoResposta);

                return usuario;

            }
            catch (HttpRequestException)
            {
                throw;
            }


        }
    }
}
