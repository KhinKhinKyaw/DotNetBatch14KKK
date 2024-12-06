
namespace DotNetBatch14KKK.RestApi3.Feature3.Blog3
{
    public interface IBlogService3
    {
        BlogResponse1 Create(BlogModel3 requestModel);
        BlogResponse1 Delete(string id);
        BlogModel3 GetBlog(string id);
        List<BlogModel3> GetBlogs();
        BlogResponse1 Update(BlogModel3 Model);
        BlogResponse1 UpInsert(BlogModel3 model);
    }
}