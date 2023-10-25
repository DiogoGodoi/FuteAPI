using FuteAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace FuteAPI.Controller
{
    public class ApiFut
    {
        private MemoryCache cache = MemoryCache.Default;
        private CacheItemPolicy politica = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(8) };
        private List<Posicao> valorEmCache = new List<Posicao>();

        public async Task<List<Posicao>> GetClubes()
        {

            valorEmCache = (List<Posicao>)cache.Get("dados");

            if(valorEmCache == null)
            {
                string url = "https://api.api-futebol.com.br/v1/campeonatos/10/tabela";

                string caminho = @"C:\Users\infra\Desktop\APIFut\FuteAPI\FuteAPI\Key.json";

                string tokenJson = File.ReadAllText(caminho);

                Token token = JsonConvert.DeserializeObject<Token>(tokenJson);

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    string dados = await response.Content.ReadAsStringAsync();
                    List<Posicao> clubes = JsonConvert.DeserializeObject<List<Posicao>>(dados);
                    cache.Add("dados", clubes, politica);

                    return clubes;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return valorEmCache;
            }   
        } 
    }
}
