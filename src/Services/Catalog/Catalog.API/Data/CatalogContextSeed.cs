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
                    Name = "SUV",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Berline",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Camion",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Bateau",
                },

                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Jet",
                },
                new CatalogModel()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Bus",
                },
            };
        }
    }
}
