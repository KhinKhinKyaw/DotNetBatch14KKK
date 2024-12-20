using DotNetBatch14KKK.ConsoleAppSnakeAndLadder;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14KKK.ConsoleAppSnakeAndLadder
{
    public  class RestClientService
    {
        public readonly string endpoint = "https://localhost:7019/api/SnakeAndLadder";
        RestClient _client;

        public RestClientService()
        {
            _client = new RestClient();
        }

        public async Task<ResponseModel> CreateGameBoard(GameBoardModel RequestGameBoard)
        {
            RestRequest request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(RequestGameBoard);

            var response = await _client.PostAsync(request);
            string content = response.Content!;

            return JsonConvert.DeserializeObject<ResponseModel>(content)!;
        }
        public async Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayerModel)
        {
            RestRequest request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(RequestPlayerModel);
            var response = await _client.PostAsync(request);

            string content = response.Content!;
            return JsonConvert.DeserializeObject<ResponseModel>(content)!;
        }

        public async Task<ResponseModel> PlayGame(int id)
        {
            RestRequest request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(id.ToString());

            var reqponse = await _client.PostAsync(request);
            string content = reqponse.Content!;

            return JsonConvert.DeserializeObject<ResponseModel>(content)!;
        }
    }
}
