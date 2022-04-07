﻿using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
    public class BuscaCep
    {

        static readonly HttpClient client = new HttpClient();


        public static async Task<Endereco> ViaCep(string cep)
        {
            try
            {
                HttpResponseMessage respostaSite = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                respostaSite.EnsureSuccessStatusCode();
                string corpoResposta = await respostaSite.Content.ReadAsStringAsync();
                var endereco = JsonConvert.DeserializeObject<Endereco>(corpoResposta);

                return endereco;
               
            }
            catch (HttpRequestException)
            {
                throw;
            }
            

        }
    }

}

