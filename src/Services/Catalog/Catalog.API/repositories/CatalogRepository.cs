using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using MongoDB.Driver;

namespace Catalog.API.repositories
{
    public class CatalogRepository :ICatalogRepository
    {
        private readonly ICatalogContext _context;

        public CatalogRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateCatalog(CatalogModel catalog)
        {
            await _context.Catalogs.InsertOneAsync(catalog);
        }

        public async Task<bool> DeleteCatalog(string id)
        {
            FilterDefinition<CatalogModel> filter = Builders<CatalogModel>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Catalogs
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByName(string name)
        {
            FilterDefinition<CatalogModel> filter = Builders<CatalogModel>.Filter.ElemMatch(p => p.Name, name);

            return await _context
                            .Catalogs
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogs()
        {
            return await _context
                            .Catalogs
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            return await _context
                           .Catalogs
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCatalog(CatalogModel catalog)
        {
            var updateResult = await _context
                                        .Catalogs
                                        .ReplaceOneAsync(filter: g => g.Id == catalog.Id, replacement: catalog);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
