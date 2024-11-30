using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KKKConsoleApp3.EFCoreExamples1
{
    public class AppDbContext1 : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings1.SqlConnectionStringBuilder.ConnectionString);
            }
        }
        public DbSet<TblBlog> Blogs { get; set; }

    }
    [Table("Tbl_Blog")]

    public class TblBlog
    {
        [Key]
        [Column("BlogId")]
        public string Id { get; set; }

        [Column("BlogTitle")]
        public string Title { get; set; }

        [Column("BlogAuthor")]
        public string Author { get; set; }

        [Column("BlogContent")]
        public string Content { get; set; }

    }
}
