using InMemoryDbSample.Model;
using InMemoryDbSample.Repository.EFCore;
using InMemoryDbSample.Repository.Interfaces;
using InMemoryDbSample.Tests.Configure;
using Moq;
using Xunit;

namespace InMemoryDbSample.Tests
{
    public class WriteRepositoryTest
    {        
        private readonly Mock<IWriteRepository> _writeRepository;
        private readonly WriteRepository _writeRepositoryClass;

        public WriteRepositoryTest()
        {
            var dbInMemory = new MemoryDbConfig();
            var context = dbInMemory.GetContext();
            _writeRepositoryClass = new WriteRepository(context);
            _writeRepository = new Mock<IWriteRepository>();
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
            _writeRepository.Setup(x => x.AddProducts(products)).Returns(_writeRepositoryClass.AddProducts(products));
                       
            var sucess = await _writeRepository.Object.AddProducts(products);

            //Assert
            Assert.True(sucess);
        }


    }
}
