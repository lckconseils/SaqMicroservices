using System;
using System.Threading.Tasks;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public interface IPanierService
    {
        Task<PanierModel> GetPanier(string userName);
    }
}
