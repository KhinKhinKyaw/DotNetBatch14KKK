using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace DotNetBatch14KKK.JsonPlaceHolder
{
    public class JsonRestClient
    {
        private readonly string endpoint = "https://jsonplaceholder.typicode.com/posts";
        private readonly RestClient _restClient;

        public JsonRestClient()
        {
            _restClient = new RestClient();
        }

        public async Task<List<JsonPlaceHolder>> GetJsons()
        {
            RestRequest request = new RestRequest(endpoint, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            string content = response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<List<JsonPlaceHolder>>(content)!;
        }

        public async Task<JsonPlaceHolder> GetJson(int id)
        {
            RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            string content = response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
        }

        public async Task<JsonPlaceHolder> CreateJson(JsonPlaceHolder requestModel)
        {
            RestRequest request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(requestModel);
            var response = await _restClient.ExecuteAsync(request);

            string content = response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
        }

        public async Task<JsonPlaceHolder> UpdateJson(JsonPlaceHolder requestModel)
        {
            RestRequest request = new RestRequest($"{endpoint}/{requestModel.id}", Method.Patch);
            request.AddJsonBody(requestModel);
            var response = await _restClient.ExecuteAsync(request);

            string content = response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
        }

        public async Task<JsonPlaceHolder> DeleteJson(int id)
        {
            RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(request);
            string content = response.Content!;
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
        }
    }
}
