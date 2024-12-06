using Azure;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;


namespace DotNetBatch14KKK.RestApi3.Feature3.Blog3
{
    public class BlogService3 : IBlogService3
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-EJAVTIJ",
            InitialCatalog = "Test",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,

        };


        public List<BlogModel3> GetBlogs()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_blog", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            List<BlogModel3> lst = new List<BlogModel3>();
            foreach (DataRow row in dt.Rows)
            {
                BlogModel3 item = new BlogModel3();
                item.BlogId = row["BlogId"].ToString()!;
                item.BlogTitle = row["BlogTitle"].ToString()!;
                item.BlogAuthor = row["BlogAuthor"].ToString()!;
                item.BlogContent = row["BlogContent"].ToString()!;
                lst.Add(item);

            }
            return lst;
        }

        public BlogModel3 GetBlog(string id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_blog where Blogid=@Blogid;", connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            BlogModel3 item = new BlogModel3();
            item.BlogId = row["BlogId"].ToString()!;
            item.BlogTitle = row["BlogTitle"].ToString()!;
            item.BlogAuthor = row["BlogAuthor"].ToString()!;
            item.BlogContent = row["BlogContent"].ToString()!;

            return item;


        }

        public BlogResponse1 Create(BlogModel3 requestModel)
        {
            string query = $@"INSERT INTO tbl_blog
                            ([BlogTitle],[BlogAuthor],[BlogContent])
                            values
                            (@BlogTitle,@BlogAuthor,@BlogContent)";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);
            cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Saving successful" : "Saving Failed";
            BlogResponse1 response1 = new BlogResponse1();
            response1.IsSuccess = result > 0;
            response1.Message = message;

            return response1;
        }

        public BlogResponse1 Update(BlogModel3 Model)
        {
            var item = GetBlog(Model.BlogId!);
            if (item is null)
            {
                return new BlogResponse1
                {
                    IsSuccess = false,
                    Message = "No data found."
                };
            }

            if (string.IsNullOrEmpty(Model.BlogTitle))
            {
                Model.BlogTitle = item.BlogTitle;
            }
            if (string.IsNullOrEmpty(Model.BlogAuthor))
            {
                Model.BlogAuthor = item.BlogAuthor;
            }
            if (string.IsNullOrEmpty(Model.BlogContent))
            {
                Model.BlogContent = item.BlogContent;
            }

            string query = @"UPDATE [dbo].[Tbl_Blog] 
                             SET [BlogTitle]=@BlogTitle,
                                    [BlogContent]=@BlogContent,
                                    [BlogAuthor]=@BlogAuthor
                                WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", Model.BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", Model.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", Model.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", Model.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string Message = result > 0 ? "Updating Successful" : "Updating Failed";
            BlogResponse1 Response1 = new BlogResponse1();
            Response1.IsSuccess = result > 0;
            Response1.Message = Message;
            return Response1;



        }


        public BlogResponse1 UpInsert(BlogModel3 model)
        {
            BlogResponse1 response = new BlogResponse1();
            var item = GetBlog(model.BlogId!);
            if (item is not null)
            {
                string query = @"UPDATE [dbo].[Tbl_Blog]
                                SET [BlogTitle]=@BlogTitle,
                                    [BlogContent]=@BlogContent,
                                    [BlogAuthor]=@BlogAuthor
                                    WHERE BlogId=@BlogId";

                #region Updating Database

                SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BlogId", model.BlogId);
                cmd.Parameters.AddWithValue("BlogTitle", model.BlogTitle);
                cmd.Parameters.AddWithValue("BlogContent", model.BlogContent);
                cmd.Parameters.AddWithValue("BlogAuthor", model.BlogAuthor);

                int result = cmd.ExecuteNonQuery();
                connection.Close();
                #endregion

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";

                response.IsSuccess = result > 0;
                response.Message = message;
            }

            else if (item is null)
            {
                response = Create(model);
            }

            return response;
        }

        public BlogResponse1 Delete(string id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Blog WHERE BlogId = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            BlogResponse1 Response1 = new BlogResponse1();
            Response1.IsSuccess = result > 0;

            Response1.Message = message;

            return Response1;
        }

    }
}


