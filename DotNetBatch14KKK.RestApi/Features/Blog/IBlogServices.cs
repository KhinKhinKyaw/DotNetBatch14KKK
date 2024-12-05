
namespace DotNetBatch14KKK.RestApi.Features.Blog
{
    public interface IBlogServices
    {
        BlogResponseModel CreateBlog(BlogModel requestModel);
        BlogResponseModel DeleteBlog(string id);
        BlogModel GetBlog(string id);
        List<BlogModel> GetBlogs();
        BlogResponseModel UpdateBlog(BlogModel requestModel);
        BlogResponseModel UpInsertBlog(BlogModel requestModel);
    }
}