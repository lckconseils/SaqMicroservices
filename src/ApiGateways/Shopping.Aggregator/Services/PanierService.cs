using System;
using System.Net.Http;
using System.Threading.Tasks;
using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class PanierService :IPanierService
    {
        private readonly HttpClient _client;

        public PanierService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<PanierModel> GetPanier(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/Panier/{userName}");
            return await response.ReadContentAs<PanierModel>();
        }
    }
}
