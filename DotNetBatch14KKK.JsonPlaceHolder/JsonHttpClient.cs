using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Refit;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetBatch14KKK.JsonPlaceHolder;

public class JsonHttpClient
{
    private readonly string endpoint = "https://jsonplaceholder.typicode.com/posts";
    private readonly HttpClient _httpClient;

    public JsonHttpClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<JsonModel>> GetJsons()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<List<JsonModel>>(content)!;
    }

    public async Task<JsonModel> GetJson(int id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<JsonModel>(content)!;

    }

    public async Task<JsonPlaceHolder> CreateJson(JsonPlaceHolder requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, stringContent);

        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
    }

    public async Task<JsonPlaceHolder> UpdateJson(JsonPlaceHolder requestModel)
    {
        string jsonStr = JsonConvert.SerializeObject(requestModel);
        var stringContent = new StringContent(jsonStr, Encoding.UTF8, Application.Json);
        HttpResponseMessage response = await _httpClient.PatchAsync($"{endpoint}/{requestModel.id}", stringContent);

        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
    }

    public async Task<JsonPlaceHolder> DeleteJson(int id)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<JsonPlaceHolder>(content)!;
    }
}
