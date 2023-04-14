using InMemoryDbSample.Model;

namespace InMemoryDbSample.Repository.Interfaces
{
    public interface IReadRepository
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
