
namespace DotNetBatch14KKK.RestApi2.Feature2.AdoDotNetExamples2
{
    public interface IBlogService2
    {
        BlogResponse Create(BlogModel2 requestModel);
        BlogResponse Delete(string id);
        BlogModel2 GetBlog(string id);
        List<BlogModel2> GetBlogs();
        BlogResponse Update(BlogModel2 Model);
        BlogResponse UpInsert(BlogModel2 model);
    }
}