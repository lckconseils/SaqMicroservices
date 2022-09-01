using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.repositories
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Product>> GetCatalogs();
        Task<Product> GetCatalog(string id);
        Task<IEnumerable<Product>> GetCatalogByName(string name);
        Task<IEnumerable<Product>> GetCatalogByCategory(string name);

        Task CreateCatalog(Product catalog);
        Task<bool> UpdateCatalog(Product catalog);
        Task<bool> DeleteCatalog(string id);
    }
}
