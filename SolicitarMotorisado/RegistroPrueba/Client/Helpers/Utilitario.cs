using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RegistroPrueba.Client.Helpers
{
    public class Utilitario : IUtilitario
    {
        private readonly HttpClient HttpClient;
        public Utilitario(HttpClient httpClient) 
        {
            HttpClient = httpClient;
        }

        public async Task<string> GetAsyncString(string url)
        {
            var response = await HttpClient.GetAsync(url);
            var resp = await response.Content.ReadAsStringAsync();
            return resp;
        }

        public async Task<string> PostAsyncString(string url, object parametro)
        {
            var json = JsonSerializer.Serialize(parametro);
            var content = new StringContent(json, Encoding.UTF8, "applicaction/json");

            var response = await HttpClient.PostAsync(url, content);
            var resp = await response.Content.ReadAsStringAsync();
            return resp;
        }
    }
}
