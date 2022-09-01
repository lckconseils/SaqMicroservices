using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;

namespace Shopping.Aggregator.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IPanierService _panierService;
        private readonly ICommandeService _commandeService;

        public ShoppingController(ICatalogService catalogService, IPanierService panierService,
            ICommandeService commandeService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _panierService = panierService ?? throw new ArgumentNullException(nameof(panierService));
            _commandeService = commandeService ?? throw new ArgumentNullException(nameof(commandeService));
        }

        [HttpGet("{userName}", Name = "GetShopping")]
        [ProducesResponseType(typeof(ShoppingModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // get basket with username
            // iterate basket items and consume products with basket item productId member
            // map product related members into basketitem dto with extended columns
            // consume ordering microservices in order to retrieve order list
            // return root ShoppngModel dto class which including all responses

            var panier = await _panierService.GetPanier(userName);

            foreach (var item in panier.Items)
            {
                var product = await _catalogService.GetCatalog(item.CatalogId);

                // set additional product fields onto basket item
                item.CatalogName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var commandes = await _commandeService.GetCommandesByUserName(userName);

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                PanierWithProducts = panier,
                Commandes = commandes
            };

            return Ok(shoppingModel);
        }
    }
}
