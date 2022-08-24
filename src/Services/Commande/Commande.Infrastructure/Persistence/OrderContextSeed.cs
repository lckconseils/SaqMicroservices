using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commande.Domaine.Entities;
using Microsoft.Extensions.Logging;

namespace Commande.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "Clauvis", FirstName = "Kitieu", LastName = "Ineat", EmailAddress = "ckitieu@ineat.ca", AddressLine = "rue du Saint-Sacrement, Montreal", Country = "Canada", TotalPrice = 350 },
                new Order() {UserName = "Clauvis", FirstName = "Kitieu", LastName = "SAQ", EmailAddress = "clauviskitieu@saq.qc.ca", AddressLine = "rue du Saint-Sacrement, Montreal", Country = "Canada", TotalPrice = 450 }
            };
        }
    }
}
