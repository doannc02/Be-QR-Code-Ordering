using Microsoft.Extensions.Configuration;
using System;

namespace OrderEats.Library.Models.DbConnection
{
    public class DatabaseConnection
    {
        private static readonly Lazy<string> _connectionString;

        static DatabaseConnection()
        {
            _connectionString = new Lazy<string>(() =>
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                return configuration.GetConnectionString("DefaultConnection");
            });
        }

        public string GetConnectionString()
        {
            return _connectionString.Value;
        }
    }
}
