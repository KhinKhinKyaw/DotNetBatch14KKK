using DotNetBatch14KKK.ConsoleAppSnakeAndLadder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14KKK.ConsoleAppSnakeAndLadder;

public class HttpClientService
{
    public readonly string endpoint = "https://localhost:7019/api/SnakeAndLadder";
    HttpClient _client;

    public HttpClientService()
    {
        _client = new HttpClient();
    }

    public async Task<ResponseModel> CreateGameBoard(GameBoardModel RequestGameBoard)
    {
        string Json = JsonConvert.SerializeObject(RequestGameBoard);
        var StringContent = new StringContent(Json, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _client.PostAsync(endpoint, StringContent);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<ResponseModel>(content)!;
    }

    public async Task<ResponseModel> CreateGame(List<PlayerModel> RequestPlayerModel)
    {
        string Json = JsonConvert.SerializeObject(RequestPlayerModel);
        var StringContent = new StringContent(Json, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _client.PostAsync(endpoint, StringContent);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<ResponseModel>(content)!;
    }

    public async Task<ResponseModel> PlayGame(int id)
    {
        string Json = JsonConvert.SerializeObject(id);
        var StringContent = new StringContent(endpoint, Encoding.UTF8, Application.Json);

        HttpResponseMessage response = await _client.PostAsync(endpoint, StringContent);
        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<ResponseModel>(content)!;
    }
}

