using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KKK.RestApi4.Feature4.Blog4
{
    public class AppDbContext4 : DbContext
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public AppDbContext4()
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
            }
        }

        public DbSet<BlogModel4> Blogs { get; set; }
    }
}

