using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
namespace DotNetBatch14KKK.JsonPlaceHolder;

public class JsonRefitService
{
    private readonly IJsonApi _api;
    public JsonRefitService()
    {
        _api = RestService.For<IJsonApi>("https://jsonplaceholder.typicode.com/");
    }

    public async Task<List<JsonPlaceHolder>> GetJsons()
    {
        var model = await _api.GetJsons();
        return model;
    }

    public async Task<JsonPlaceHolder> GetJson(int id)
    {
        var model = await _api.GetJson(id);
        return model;
    }

    public async Task<JsonPlaceHolder> CreateJson(JsonPlaceHolder requestjson)
    {
        var model = await _api.CreateJson(requestjson);
        return model;
    }

    public async Task<JsonPlaceHolder> UpdateJson(int id, JsonPlaceHolder requestjson)
    {
        var model = await _api.UpdateJson(id, requestjson);
        return model;
    }

    public async Task<JsonPlaceHolder> DeleteJson(int id)
    {
        var model = await _api.DeleteJson(id);
        return model;
    }
}

public interface IJsonApi
{
    [Get("/posts")]
    Task<List<JsonPlaceHolder>> GetJsons();

    [Get("/posts/{id}")]
    Task<JsonPlaceHolder> GetJson(int id);

    [Post("/posts")]
    Task<JsonPlaceHolder> CreateJson(JsonPlaceHolder requestjson);

    [Patch("/posts")]
    Task<JsonPlaceHolder> UpdateJson(int id,JsonPlaceHolder requestjson);

    [Delete("/posts")]

    Task<JsonPlaceHolder> DeleteJson(int id);
}


public class JsonPlaceHolder
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}
