using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Panier.Api.GrpcServices;
using Panier.Api.Repositories;

namespace Panier.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PanierController : ControllerBase
    {
        private readonly IPanierRepository _repository;
        private readonly PromotionGrpcService _discountGrpcService;
        private readonly IMapper _mapper;

        public PanierController(IPanierRepository repository, PromotionGrpcService promotionGrpcService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _discountGrpcService = promotionGrpcService ?? throw new ArgumentNullException(nameof(promotionGrpcService));
        }


        [HttpGet("{userName}", Name = "GetPanier")]
        [ProducesResponseType(typeof(Panier), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Panier>> GetPanier(string userName)
        {
            var basket = await _repository.GetPanier(userName);
            return Ok(basket ?? new Panier(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Panier), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Panier>> UpdatePanier([FromBody] Panier basket)
        {
            //// Communicate with Discount.Grpc and calculate lastest prices of products into sc
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetPromotionApi(item.CatalogName);
                item.Price -= coupon.Montant;
            }

            return Ok(await _repository.UpdatePanier(basket));
        }

        [HttpDelete("{userName}", Name = "DeletePanier")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePanier(string userName)
        {
            await _repository.DeletePanier(userName);
            return Ok();
        }

        //[Route("[action]")]
        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.Accepted)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Checkout([FromBody] PanierValidation basketCheckout)
        //{
        //    // get existing basket with total price            
        //    // Set TotalPrice on basketCheckout eventMessage
        //    // send checkout event to rabbitmq
        //    // remove the basket

        //    // get existing basket with total price
        //    var basket = await _repository.GetPanier(basketCheckout.UserName);
        //    if (basket == null)
        //    {
        //        return BadRequest();
        //    }

        //    // send checkout event to rabbitmq
        //    var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
        //    eventMessage.TotalPrice = basket.TotalPrice;
        //    await _publishEndpoint.Publish<BasketCheckoutEvent>(eventMessage);

        //    // remove the basket
        //    await _repository.DeletePanier(basket.UserName);

        //    return Accepted();
        //}
    }
}
