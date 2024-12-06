using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KKK.RestApi2.Feature2.AdoDotNetExamples2
{
    public class BlogEFCoreService2 : IBlogService2
    {
        private readonly AppDbContext2 _db;

        public BlogEFCoreService2()
        {
            _db = new AppDbContext2();
        }

        public BlogResponse Create(BlogModel2 requestModel)
        {
            _db.Blogs.Add(requestModel);
            var result = _db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponse model = new BlogResponse();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse Delete(string id)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return new BlogResponse
                {
                    IsSuccess = false,
                    Message = "No data found."
                };
            }

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            BlogResponse model = new BlogResponse();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel2 GetBlog(string id)
        {
            var item = _db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            return item!;
        }

        public List<BlogModel2> GetBlogs()
        {
            var lst = _db.Blogs
                .AsNoTracking()
                .ToList();
            return lst;
        }

        public BlogResponse Update(BlogModel2 requestModel)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == requestModel.BlogId);
            if (item is null)
            {
                return new BlogResponse
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
            BlogResponse model = new BlogResponse();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse UpInsert(BlogModel2 requestModel)
        {
            BlogResponse model = new BlogResponse();
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == requestModel.BlogId);
            if (item is null)
            {
                model = Create(requestModel);
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

