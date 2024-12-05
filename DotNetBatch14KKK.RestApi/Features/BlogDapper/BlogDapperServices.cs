using System.Data;
using Dapper;
using DotNetBatch14KKK.RestApi.Features.Blog;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KKK.RestApi.Features.BlogDapper
{
    public class BlogDapperServices : IBlogServices
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public BlogDapperServices()
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-EJAVTIJ",
                InitialCatalog = "Test",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
        }
        public List<BlogModel> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var lst = db.Query<BlogModel>(query).ToList();
            return lst;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var item = db.QueryFirstOrDefault<BlogModel>(query);
            return item!;
        }

        public BlogResponseModel CreateBlog(BlogModel requestModel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
                             ([BlogTitle]
                            ,[BlogAuthor]
                            ,[BlogContent])
                             VALUES
                            (@BlogTitle
                             ,@BlogAuthor
                            ,@BlogContent)";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, requestModel);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel UpdateBlog(BlogModel requestModel)
        {
            var item = GetBlog(requestModel.BlogId!);
            if (item is null)
            {
                return new BlogResponseModel
                {
                    IsSuccess = false,
                    Message = "No data found."
                };
            }

            if (string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                requestModel.BlogTitle = item.BlogTitle;
            }
            if (string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                requestModel.BlogAuthor = item.BlogAuthor;
            }
            if (string.IsNullOrEmpty(requestModel.BlogContent))
            {
                requestModel.BlogContent = item.BlogContent;
            }

            string query = @"UPDATE [dbo].[Tbl_Blog]
                             SET [BlogTitle] = @BlogTitle
                             ,[BlogAuthor] = @BlogAuthor
                             ,[BlogContent] = @BlogContent
                                WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, requestModel);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel UpInsertBlog(BlogModel requestModel)
        {
            BlogResponseModel model = new BlogResponseModel();

            var item = GetBlog(requestModel.BlogId!);
            if (item is not null)
            {
                string query = @"UPDATE [dbo].[Tbl_Blog]
                                 SET [BlogTitle] = @BlogTitle
                                 ,[BlogAuthor] = @BlogAuthor
                                ,[BlogContent] = @BlogContent
                                WHERE BlogId = @BlogId";

                #region Update Database

                using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                var result = db.Execute(query, requestModel);

                #endregion

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";

                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if (item is null)
            {
                model = CreateBlog(requestModel);
            }

            return model;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = "Delete from [dbo].[Tbl_Blog] where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, new BlogModel
            {
                BlogId = id
            });

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}