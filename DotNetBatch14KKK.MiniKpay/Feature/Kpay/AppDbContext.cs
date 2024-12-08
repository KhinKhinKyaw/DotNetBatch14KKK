using DotNetBatch14KKK.MiniKpay.Feature.Kpay;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    public class AppDbContext : DbContext
    {
        public readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public AppDbContext()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
                InitialCatalog = "DotNetBatch14_Transfer",
                UserID = "sa",
                Password = "p@ssw0rd",
                TrustServerCertificate = true
            };
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
