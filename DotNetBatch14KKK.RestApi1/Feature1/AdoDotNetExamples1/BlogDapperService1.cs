using System.Data;
using Dapper;
using DotNetBatch14KKK.RestApi1.Feature1.AdoDotNetExamples1;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KKK.RestApi1.Feature1.AdoDotNetExamples1
{
    public class BlogDapperService1 : IBlogService1
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public BlogDapperService1()
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
        public List<BlogModel1> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var lst = db.Query<BlogModel1>(query).ToList();
            return lst;
        }

        public BlogModel1 GetBlog(string id)
        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var item = db.QueryFirstOrDefault<BlogModel1>(query);
            return item!;
        }

        public BlogResponse1 Create(BlogModel1 requestModel)
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
            BlogResponse1 model = new BlogResponse1();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse1 Update(BlogModel1 requestModel)
        {
            var item = GetBlog(requestModel.BlogId!);
            if (item is null)
            {
                return new BlogResponse1
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
            BlogResponse1 model = new BlogResponse1();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse1 UpInsert(BlogModel1 requestModel)
        {
            BlogResponse1 model = new BlogResponse1();

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
                model = Create(requestModel);
            }

            return model;
        }

        public BlogResponse1 Delete(string id)
        {
            string query = "Delete from [dbo].[Tbl_Blog] where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, new BlogModel1
            {
                BlogId = id
            });

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            BlogResponse1 model = new BlogResponse1();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}
