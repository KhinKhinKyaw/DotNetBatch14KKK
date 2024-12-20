
namespace DotNetBatch14KKK.DreamDictionary
{
    public interface IDreamDictionaryRefit
    {
        Task<DreamModel> GetDream(int id);
        Task<List<DreamModel>> GetDreams();
    }
}