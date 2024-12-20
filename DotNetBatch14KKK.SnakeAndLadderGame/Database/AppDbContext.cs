
using DotNetBatch14KKK.SnakeAndLadderGame.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace DotNetBatch14KKK.SnakeAndLadderGame.Database;

public class AppDbContext:DbContext
{
    public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
    public AppDbContext()
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-EJAVTIJ",
            UserID = "sa",
            Password = "sa@123",
            InitialCatalog = "DotNetBatch14_UpdateSnakeLadder",
            TrustServerCertificate = true
        };
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public DbSet<PlayerModel> Players { get; set; }
    public DbSet<GameBoardModel> GameBoards { get; set; }
    public DbSet<GameModel> Games { get; set; }
    public DbSet<GameMoveModel> GameMoves { get; set; }
}
