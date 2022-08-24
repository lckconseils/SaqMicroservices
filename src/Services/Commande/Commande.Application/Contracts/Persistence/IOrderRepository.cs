﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commande.Domaine.Entities;

namespace Commande.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
