using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefa.App.Data
{
    public class CustomHttpClient : HttpClient
    {
        public async Task<T> GetJsonAsync<T>(string requestUri)
        {
            using HttpClient httpClient = new HttpClient();
            using var httpContent = await httpClient.GetAsync(requestUri);
            string jsonContent = httpContent.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }

        public async Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T content)
        {
            using HttpClient httpClient = new HttpClient();
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, stringContent);
            return response;
        }

        public async Task<HttpResponseMessage> PutJonsAsync<T>(string requestUri, T content)
        {
            using HttpClient httpClient = new HttpClient();
            string myContent = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(requestUri, stringContent);
        }
    }
}
