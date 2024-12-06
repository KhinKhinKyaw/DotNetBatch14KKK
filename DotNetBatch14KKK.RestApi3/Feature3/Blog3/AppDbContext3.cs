using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KKK.RestApi3.Feature3.Blog3
{
    public class AppDbContext3 : DbContext
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public AppDbContext3()
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

        public DbSet<BlogModel3> Blogs { get; set; }
    }
}

