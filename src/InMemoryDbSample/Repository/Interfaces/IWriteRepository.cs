using InMemoryDbSample.Model;

namespace InMemoryDbSample.Repository.Interfaces
{
    public interface IWriteRepository : IDisposable
    {
        Task<bool> AddProducts(IEnumerable<Product> products);
    }
}
