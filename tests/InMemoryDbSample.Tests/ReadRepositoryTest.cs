using InMemoryDbSample.Repository.Dapper;
using InMemoryDbSample.Repository.EFCore;
using InMemoryDbSample.Repository.Interfaces;
using InMemoryDbSample.Tests.Configure;
using Moq;
using Xunit;

namespace InMemoryDbSample.Tests
{
    public class ReadRepositoryTest
    {
        private readonly Mock<IReadRepository> _readRepository;
        private readonly ReadRepository _readRepositoryClass;        
        public ReadRepositoryTest()
        {
            var dbInMemory = new MemoryDbConfig();            
            var idbConnection = dbInMemory.GetIDbContext();
            _readRepositoryClass = new ReadRepository(idbConnection);
            _readRepository = new Mock<IReadRepository>();            
        }


        [Fact]
        public async Task Must_get_all_products()
        {
            //Act
            _readRepository.Setup(x => x.GetAll()).Returns(_readRepositoryClass.GetAll());            

            var products = await _readRepository.Object.GetAll();

            //Assert
            Assert.Equal(2, products.Count());
        }        
    }
}
