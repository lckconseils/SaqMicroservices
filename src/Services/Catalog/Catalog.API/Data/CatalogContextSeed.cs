using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<CatalogModel> catalogCollection)
        {
            bool existProduct = catalogCollection.Find(p => true).Any();
            if (!existProduct)
            {
                catalogCollection.InsertManyAsync(GetPreconfiguredCatalogs());
            }
        }

        private static IEnumerable<CatalogModel> GetPreconfiguredCatalogs()
        {
            return new List<CatalogModel>()
            {
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Spiritueux",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Vin",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Champagne",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Bière",
                },

                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Cidre",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Saké",
                },
            };
        }
    }
}
