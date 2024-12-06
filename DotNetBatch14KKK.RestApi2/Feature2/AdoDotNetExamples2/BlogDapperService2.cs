﻿using System.Data;
using Dapper;
using DotNetBatch14KKK.RestApi2.Feature2.AdoDotNetExamples2;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14KKK.RestApi2.Feature2.AdoDotNetExamples2
{
    public class BlogDapperService2 : IBlogService2
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public BlogDapperService2()
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
        public List<BlogModel2> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var lst = db.Query<BlogModel2>(query).ToList();
            return lst;
        }

        public BlogModel2 GetBlog(string id)
        {
            string query = "select * from tbl_blog with (nolock)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var item = db.QueryFirstOrDefault<BlogModel2>(query);
            return item!;
        }

        public BlogResponse Create(BlogModel2 requestModel)
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
            BlogResponse model = new BlogResponse();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse Update(BlogModel2 requestModel)
        {
            var item = GetBlog(requestModel.BlogId!);
            if (item is null)
            {
                return new BlogResponse
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
            BlogResponse model = new BlogResponse();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponse UpInsert(BlogModel2 requestModel)
        {
            BlogResponse model = new BlogResponse();

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

        public BlogResponse Delete(string id)
        {
            string query = "Delete from [dbo].[Tbl_Blog] where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, new BlogModel2
            {
                BlogId = id
            });

            string message = result > 0 ? "Delete Success." : "Delete Fail!";
            BlogResponse model = new BlogResponse();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}
