using Microsoft.EntityFrameworkCore;


namespace DotNetBatch14KKK.RestApi4.Feature4.Blog4
{
    public class BlogEFCoreService4 : IBlogService4
    {
        private readonly AppDbContext4 _db;

        public BlogEFCoreService4()
        {
            _db = new AppDbContext4();
        }

        public BlogResponse1 Create(BlogModel4 requestModel)
        {
            _db.Blogs.Add(requestModel);
            var result = _db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponse1 model = new BlogResponse1();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse1 Delete(string id)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return new BlogResponse1
                {
                    IsSuccess = false,
                    Message = "No data found."
                };
            }

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            BlogResponse1 model = new BlogResponse1();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel4 GetBlog(string id)
        {
            var item = _db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            return item!;
        }

        public List<BlogModel4> GetBlogs()
        {
            var lst = _db.Blogs
                .AsNoTracking()
                .ToList();
            return lst;
        }

        public BlogResponse1 Update(BlogModel4 requestModel)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == requestModel.BlogId);
            if (item is null)
            {
                return new BlogResponse1
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
            BlogResponse1 model = new BlogResponse1();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse1 UpInsert(BlogModel4 requestModel)
        {
            BlogResponse1 model = new BlogResponse1();
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


