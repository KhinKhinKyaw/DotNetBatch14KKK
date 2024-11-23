using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp2
{
    public class AppSettings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder { get; } = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-EJAVTIJ",
            InitialCatalog = "Test",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true

        };
    }
}
