
namespace DotNetBatch14KKK.RestApi1.Feature1.AdoDotNetExamples1
{
    public interface IBlogService1
    {
        BlogResponse1 Create(BlogModel1 requestModel);
        BlogResponse1 Delete(string id);
        BlogModel1 GetBlog(string id);
        List<BlogModel1> GetBlogs();
        BlogResponse1 Update(BlogModel1 Model);
        BlogResponse1 UpInsert(BlogModel1 model);
    }
}