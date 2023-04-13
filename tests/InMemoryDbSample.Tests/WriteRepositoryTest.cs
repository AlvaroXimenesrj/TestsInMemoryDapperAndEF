using InMemoryDbSample.Model;
using InMemoryDbSample.Repository.Dapper;
using InMemoryDbSample.Repository.EFCore;
using InMemoryDbSample.Tests.Configure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InMemoryDbSample.Tests
{
    public class WriteRepositoryTest
    {
        private readonly WriteRepository _writeRepository;
        public WriteRepositoryTest()
        {
            var dbInMemory = new MemoryDbConfig();
            var context = dbInMemory.GetContext();
            _writeRepository = new WriteRepository(context);
        }

        [Fact]
        public async Task Must_add_products()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product("product test 1", true),
            new Product("product test 2", false)
            };
            //Act
            
            var sucess = await _writeRepository.AddProducts(products);

            //Assert
            Assert.True(sucess);
        }


    }
}
