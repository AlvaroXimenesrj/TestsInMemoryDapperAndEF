using InMemoryDbSample.Model;
using InMemoryDbSample.Repository.Interfaces;

namespace InMemoryDbSample.Repository.EFCore
{
    public class WriteRepository : IWriteRepository
    {
        private readonly DbProductContext _context;
        public WriteRepository(DbProductContext context)
        {
            _context = context;
        }
        public async Task AddProducts(IEnumerable<Product> products)
        {
            _context.Database.EnsureCreated();

            await _context.AddRangeAsync(products);

            await _context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
