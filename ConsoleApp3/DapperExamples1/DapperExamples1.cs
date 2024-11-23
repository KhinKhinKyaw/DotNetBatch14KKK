using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp3.Dtos1;

namespace ConsoleApp3.DapperExamples1
{
    public class DapperExamples1
    {
        private readonly string _connectionString = AppSettings1.SqlConnectionStringBuilder.ConnectionString;
        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);


            List<BlogDto1> lst = connection
                 .Query<BlogDto1>("select * from tbl_blog")
                 .ToList();

            foreach (BlogDto1 item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            var item = connection
                 .Query<BlogDto1>($"select * from tbl_blog where BlogId = '{id}'")
                 .FirstOrDefault();

            //if(item == null)
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

            using IDbConnection connection = new SqlConnection(_connectionString);
            var result = connection.Execute(query);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update(string id, string title)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var item = connection
                .Query<BlogDto1>($"Update tbl_blog set BlogTitle='{title}' where BlogId='{id}'")
                .FirstOrDefault();

        }

        public void Delete(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var item = connection
                .Query<BlogDto1>($"DELETE FROM tbl_blog WHERE BlogId='{id}'")
                .FirstOrDefault();
        }

    }

}
