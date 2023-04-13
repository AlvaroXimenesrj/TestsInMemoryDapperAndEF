using Dapper;
using InMemoryDbSample.Model;
using InMemoryDbSample.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDbSample.Repository.Dapper
{
    public class ReadRepository : IReadRepository
    {
        private readonly IDbConnection _connection;
        public ReadRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var sqlCommand = @"SELECT * FROM Products";

            var products = await _connection.QueryAsync<Product>(sqlCommand);

            return products;
        }
    }
}
