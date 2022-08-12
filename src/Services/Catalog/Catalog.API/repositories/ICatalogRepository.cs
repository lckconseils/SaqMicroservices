using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.repositories
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogModel>> GetCatalogs();
        Task<CatalogModel> GetCatalog(int id);
        Task<IEnumerable<CatalogModel>> GetCatalogByName(string name);

        Task CreateCatalog(CatalogModel catalog);
        Task<bool> UpdateCatalog(CatalogModel catalog);
        Task<bool> DeleteCatalog(int id);
    }
}
