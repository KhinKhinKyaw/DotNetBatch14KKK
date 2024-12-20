using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace DotNetBatch14KKK.DreamDictionary;

public class DreamDictionaryRestClient
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/dream-dictionary";
    private readonly RestClient _restClient;

    public DreamDictionaryRestClient()
    {
        _restClient = new RestClient();
    }

    public async Task<List<DreamDictionaryModel>> GetDreams()
    {
        RestRequest request = new RestRequest(endpoint, Method.Get);
        var response = await _restClient.ExecuteAsync(request);
        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<List<DreamDictionaryModel>>(content)!;
    }

    public async Task<DreamDictionaryModel> GetDream(string id)
    {
        RestRequest request = new RestRequest($"{endpoint}/{id}", Method.Get);
        var response = await _restClient.ExecuteAsync(request);
        string content = response.Content!;
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<DreamDictionaryModel>(content)!;
    }
}


