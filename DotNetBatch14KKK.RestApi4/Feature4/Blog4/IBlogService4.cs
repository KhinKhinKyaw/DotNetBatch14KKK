
namespace DotNetBatch14KKK.RestApi4.Feature4.Blog4
{
    public interface IBlogService4
    {
        BlogResponse1 Create(BlogModel4 requestModel);
        BlogResponse1 Delete(string id);
        BlogModel4 GetBlog(string id);
        List<BlogModel4> GetBlogs();
        BlogResponse1 Update(BlogModel4 Model);
        BlogResponse1 UpInsert(BlogModel4 model);
    }
}