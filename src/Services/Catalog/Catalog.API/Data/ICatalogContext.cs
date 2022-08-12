using System;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<CatalogModel> Catalogs { get; }
    }
}
