using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Panier.Api.Repositories
{
    public class PanierRepository : IPanierRepository
    {
        private readonly IDistributedCache _redisCache;

        public PanierRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task DeletePanier(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<Panier> GetPanier(string userName)
        {
            var panier = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(panier))
                return null;

            return JsonConvert.DeserializeObject<Panier>(panier);
        }

        public async Task<Panier> UpdatePanier(Panier panier)
        {
            await _redisCache.SetStringAsync(panier.UserName, JsonConvert.SerializeObject(panier));

            return await GetPanier(panier.UserName);
        }
    }
}
