using InMemoryDbSample.Repository.Dapper;
using InMemoryDbSample.Tests.Configure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InMemoryDbSample.Tests
{
    public class ReadRepositoryTest
    {
        private readonly ReadRepository _readRepository;        
        public ReadRepositoryTest()
        {
            var dbInMemory = new MemoryDbConfig();            
            var idbConnection = dbInMemory.GetIDbContext();
            _readRepository = new ReadRepository(idbConnection);
        }


        [Fact]
        public async Task Must_get_all_products()
        {
            //Act
            var products = await _readRepository.GetAll();

            //Assert
            Assert.Equal(2, products.Count());
        }        
    }
}
