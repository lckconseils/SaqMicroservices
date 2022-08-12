using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<CatalogModel> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<CatalogModel> GetPreconfiguredProducts()
        {
            return new List<CatalogModel>()
            {
                new CatalogModel()
                {
                    Id = 1,
                    Name = "SUV",
                },
                new CatalogModel()
                {
                    Id = 2,
                    Name = "Berline",
                },
                new CatalogModel()
                {
                    Id = 3,
                    Name = "Camion",
                },
                new CatalogModel()
                {
                    Id = 4,
                    Name = "Bateau",
                },

                new CatalogModel()
                {
                    Id = 5,
                    Name = "Jet",
                },
                new CatalogModel()
                {
                    Id = 6,
                    Name = "Bus",
                },
            };
        }
    }
}
