using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Refit;

namespace DotNetBatch14KKK.DreamDictionary;

public class DreamDictionaryHttpClient
{
    private readonly string endpoint = "https://burma-project-ideas.vercel.app/dream-dictionary";
    private readonly HttpClient _httpClient;

    public DreamDictionaryHttpClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<DreamDictionaryModel>> GetDreams()
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<List<DreamDictionaryModel>>(content)!;
    }

    public async Task<DreamDictionaryResponseModel> GetDream(int id)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        return JsonConvert.DeserializeObject<DreamDictionaryResponseModel>(content)!;
    }

   
}

