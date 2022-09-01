using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CommandeService : ICommandeService
    {
        private readonly HttpClient _client;

        public CommandeService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CommandeResponseModel>> GetCommandesByUserName(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/Commande/{userName}");
            return await response.ReadContentAs<List<CommandeResponseModel>>();
        }
    }
}
