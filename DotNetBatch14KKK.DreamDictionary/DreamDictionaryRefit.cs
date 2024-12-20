using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace DotNetBatch14KKK.DreamDictionary;

public class DreamDictionaryRefit : IDreamDictionaryRefit
{

    private readonly IDreamApi _api;

    public DreamDictionaryRefit()
    {
        _api = RestService.For<IDreamApi>("https://burma-project-ideas.vercel.app/");
    }
    public async Task<List<DreamModel>> GetDreams()
    {
        var model = await _api.GetDreams();
        return model;
    }

    public async Task<DreamModel> GetDream(int id)
    {
        var model = await _api.GetDream(id);
        return model;
    }
}

public interface IDreamApi
    {
        [Get("/dream-dictionary")]
        Task<List<DreamModel>> GetDreams();

        [Get("/dream-dictionary/{id}")]
        Task<DreamModel> GetDream(int id);
    }


    public class DreamModel
    {
        public int groupId { get; set; }
        public string title { get; set; }
    }
