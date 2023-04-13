using InMemoryDbSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDbSample.Repository.Interfaces
{
    public interface IWriteRepository : IDisposable
    {
        Task AddProducts(IEnumerable<Product> products);
    }
}
