using InMemoryDbSample.Model;
using InMemoryDbSample.Repository.Interfaces;

namespace InMemoryDbSample.Services
{
    public class Execute : IExecute
    {
        private readonly IReadRepository _readRepository;
        private readonly IWriteRepository _writeRepository;

        public Execute(IReadRepository readRepository,
                       IWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;

        }
        public async Task ExecuteAsync()
        {
            var newProducts = Product.CreateProducts();

            await _writeRepository.AddProducts(newProducts);

            var products = await _readRepository.GetAll();


        }
    }

    public interface IExecute
    {
        Task ExecuteAsync();
    }
}
