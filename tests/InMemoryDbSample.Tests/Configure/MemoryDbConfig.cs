using InMemoryDbSample.Model;
using InMemoryDbSample.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InMemoryDbSample.Tests.Configure
{
    public class MemoryDbConfig
    {
        private DbProductContext _context;

        private IDbConnection Connection { get; set; }
        public ConnectionState State => this.Connection.State;
        public MemoryDbConfig()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            this.Connection = connection;
            connection.Open();

            var options = new DbContextOptionsBuilder<DbProductContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new DbProductContext(options);
            InsertFakeData();
        }

        public DbProductContext GetContext() => _context;
        public IDbConnection GetIDbContext() => Connection;

        private void InsertFakeData()
        {
            if (_context.Database.EnsureCreated())
            {
                _context.Products.Add(
                    new Product("Product TEST 1", true)
                );
                _context.Products.Add(
                    new Product("Product TEST 2", true)
                );

                _context.SaveChanges();
            }
        }
    }
}
