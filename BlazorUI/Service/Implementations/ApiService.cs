using Newtonsoft.Json;
using System.Text;
using UI.Service.Interfaces;

namespace UI.Service.Implementations
{
    public class ApiService<T> : IApiService<T>
    {
        HttpClient client;

        public ApiService(HttpClient _client)
        {
            client = _client;
        }

        public async Task<List<T>> GetAllByUriAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            SucsessChecking(response);

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<T>>(result);
        }

        public async Task<T> GetEntityByUriAsync(string uri)
        {
            var response = await client.GetAsync(uri);
            SucsessChecking(response);

            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task CreateAsync(IEnumerable<object> entitys, string uri)
        {
            var response = await client.PostAsync(uri, ContentFromEntity(entitys));
            SucsessChecking(response);
        }

        public async Task UpdateAsync(object entity, string uri)
        {
            var response = await client.PutAsync(uri, ContentFromEntity(entity));
            SucsessChecking(response);
        }

        public async Task DeleteAsync(string uri)
        {
            var result = await client.DeleteAsync(uri);
            SucsessChecking(result);
        }

        private void SucsessChecking(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Reason: {response.ReasonPhrase}, Message: {response.Content}");
            }
        }

        private StringContent ContentFromEntity(object entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        }

    }
}
