using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KKK.RestApi.Features.Blog
{
    public class BlogEFCoreService  : IBlogServices
    {
            private readonly AppDbContext _db;

            public BlogEFCoreService()
            {
                _db = new AppDbContext();
            }

            public BlogResponseModel CreateBlog(BlogModel requestModel)
            {
                _db.Blogs.Add(requestModel);
                var result = _db.SaveChanges();

                string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                BlogResponseModel model = new BlogResponseModel();
                model.IsSuccess = result > 0;
                model.Message = message;

                return model;
            }

            public BlogResponseModel DeleteBlog(string id)
            {
                var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return new BlogResponseModel
                    {
                        IsSuccess = false,
                        Message = "No data found."
                    };
                }

                _db.Entry(item).State = EntityState.Deleted;
                var result = _db.SaveChanges();

                string message = result > 0 ? "Delete Success." : "Delete Fail!";
                BlogResponseModel model = new BlogResponseModel();
                model.IsSuccess = result > 0;
                model.Message = message;

                return model;
            }

            public BlogModel GetBlog(string id)
            {
                var item = _db.Blogs
                    .AsNoTracking()
                    .FirstOrDefault(x => x.BlogId == id);
                return item!;
            }

            public List<BlogModel> GetBlogs()
            {
                var lst = _db.Blogs
                    .AsNoTracking()
                    .ToList();
                return lst;
            }

            public BlogResponseModel UpdateBlog(BlogModel requestModel)
            {
                var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == requestModel.BlogId);
                if (item is null)
                {
                    return new BlogResponseModel
                    {
                        IsSuccess = false,
                        Message = "No data found."
                    };
                }

                if (!string.IsNullOrEmpty(requestModel.BlogTitle))
                {
                    item.BlogTitle = requestModel.BlogTitle;
                }
                if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
                {
                    item.BlogAuthor = requestModel.BlogAuthor;
                }
                if (!string.IsNullOrEmpty(requestModel.BlogContent))
                {
                    item.BlogContent = requestModel.BlogContent;
                }

                _db.Entry(item).State = EntityState.Modified;
                var result = _db.SaveChanges();

                string message = result > 0 ? "Updating Successful" : "Updating Failed.";
                BlogResponseModel model = new BlogResponseModel();
                model.IsSuccess = result > 0;
                model.Message = message;

                return model;
            }

            public BlogResponseModel UpInsertBlog(BlogModel requestModel)
            {
                BlogResponseModel model = new BlogResponseModel();
                var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == requestModel.BlogId);
                if (item is null)
                {
                    model = CreateBlog(requestModel);
                    return model;
                }

                #region Update Blog

                if (!string.IsNullOrEmpty(requestModel.BlogTitle))
                {
                    item.BlogTitle = requestModel.BlogTitle;
                }
                if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
                {
                    item.BlogAuthor = requestModel.BlogAuthor;
                }
                if (!string.IsNullOrEmpty(requestModel.BlogContent))
                {
                    item.BlogContent = requestModel.BlogContent;
                }


                _db.Entry(item).State = EntityState.Modified;
                var result = _db.SaveChanges();

                string message = result > 0 ? "Updating Successful" : "Updating Failed.";
                model.IsSuccess = result > 0;
                model.Message = message;

                #endregion

                return model;
            }
        }
    }
