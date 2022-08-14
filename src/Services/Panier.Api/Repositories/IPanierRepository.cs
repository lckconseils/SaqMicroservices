using System;
using System.Threading.Tasks;

namespace Panier.Api.Repositories
{
    public interface IPanierRepository
    {
        Task<Panier> GetPanier(string userName);
        Task<Panier> UpdatePanier(Panier basket);
        Task DeletePanier(string userName);
    }
}
