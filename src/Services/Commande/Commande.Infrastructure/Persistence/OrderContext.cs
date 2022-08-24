using System;
using System.Threading;
using System.Threading.Tasks;
using Commande.Domaine.Common;
using Commande.Domaine.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commande.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Yves";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Paul";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
