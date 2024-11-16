using Microsoft.Data.SqlClient;
using System.Data;
SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.DataSource = ".";//server name
connectionStringBuilder.InitialCatalog = "TestDb";//db name
connectionStringBuilder.UserID = "sa";
connectionStringBuilder.Password = "sasa@123";
SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
Console.WriteLine("Connection Open...");
connection.Open();
Console.WriteLine("Connection Open...");
Console.WriteLine("Connection Close...");
connection.Close();
Console.WriteLine("Connection Close...");
string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt=new DataTable();
adapter.Fill(dt);
connection .Close();    
foreach(DataRow dr in dt.Rows)
{
   Console.WriteLine( dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);

}


namespace DotNetBatch14KKK.ConsoleApp


{
    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
