using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface ICommandeService
    {
        Task<IEnumerable<CommandeResponseModel>> GetCommandesByUserName(string userName);
    }
}
