using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> catalogCollection)
        {
            bool existProduct = catalogCollection.Find(p => true).Any();
            if (!existProduct)
            {
                catalogCollection.InsertManyAsync(GetPreconfiguredCatalogs());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredCatalogs()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "601d2149e773f2a3990b47f5",
                    Name = "Bartenura Prosecco",
                    Summary = "Champagne de haute qualité",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 250.00M,
                    Category = "Champagne"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Bernard-Massard Cuvée de L'Écusson Brut",
                    Summary = "Champagne de haute qualité",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 250.00M,
                    Category = "Champagne"
                },
                new Product()
                {
                    Id = "603d2149e773f2a3990b47f6",
                    Name = "19 Crimes Hard Chard",
                    Summary = "Vin provenant des vignes de Brossard.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 100.00M,
                    Category = "Vin"
                },
                new Product()
                {
                    Id = "604d2149e773f2a3990b47f6",
                    Name = "AA Badenhorst Secateurs Rosé 2021",
                    Summary = "Vin provenant des vignes de Brossard.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 100.00M,
                    Category = "Vin"
                },
                new Product()
                {
                    Id = "605d2149e773f2a3990b47f7",
                    Name = "1800 Blanco",
                    Summary = "Spiritueux de qualité et fabriqué au Québec.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 60.00M,
                    Category = "Spiritueux"
                },
                new Product()
                {
                    Id = "606d2149e773f2a3990b47f7",
                    Name = "1989 Taffel Akvavit",
                    Summary = "Spiritueux de qualité et fabriqué au Québec.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 60.00M,
                    Category = "Spiritueux"
                },
                new Product()
                {
                    Id = "607d2149e773f2a3990b47f8",
                    Name = "Boon Framboise Lambic",
                    Summary = "Très bonne variété de bière.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 30.00M,
                    Category = "Biere"
                },
                new Product()
                {
                    Id = "608d2149e773f2a3990b47f8",
                    Name = "St-Ambroise West Coast IPA",
                    Summary = "Très bonne variété de bière.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 30.00M,
                    Category = "Biere"
                },
                new Product()
                {
                    Id = "609d2149e773f2a3990b99f9",
                    Name = "Château de Cartes",
                    Summary = "Cidre artisanal, fait avec les produits du terroir",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 40.00M,
                    Category = "Cidre"
                },
                new Product()
                {
                    Id = "610d2149e773f2a3990b47f9",
                    Name = "Cidrerie du Minot Brut",
                    Summary = "Cidre artisanal, fait avec les produits du terroir",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 40.00M,
                    Category = "Cidre"
                },
                new Product()
                {
                    Id = "611d2149e773f2a3990b99fa",
                    Name = "Intermiel Benoîte",
                    Summary = "Hydromel biologique sans sucre ajouté.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 90.00M,
                    Category = "Hydromel"
                },
                new Product()
                {
                    Id = "612d2149e773f2a3990b47fa",
                    Name = "Intermiel Bouquet Printanier",
                    Summary = "Hydromel biologique sans sucre ajouté.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 90.00M,
                    Category = "Hydromel"
                }
            };
        }
    }
}
