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
        public async Task<bool> AddProducts(IEnumerable<Product> products)
        {
            _context.Database.EnsureCreated();

            await _context.AddRangeAsync(products);

            return await _context.SaveChangesAsync() > 0;

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
