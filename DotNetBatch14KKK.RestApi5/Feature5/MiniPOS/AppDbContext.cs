using DotNetBatch14KKK.RestApi5.Feature5.MiniPOS;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DotNetBatch14KKK.RestApi5.Feature5.MiniPOS
{
    public class AppDbContext : DbContext
    {
        public readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public AppDbContext()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-EJAVTIJ",
                InitialCatalog = "DotNetBatch14_MiniPOS",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}

