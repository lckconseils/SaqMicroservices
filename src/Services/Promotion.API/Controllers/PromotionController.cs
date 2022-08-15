using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promotion.API.Repositories;

namespace Promotion.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _repository;

        public PromotionController(IPromotionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{productName}", Name = "GetPromotion")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetPromotion(string productName)
        {
            var discount = await _repository.GetPromotion(productName);
            return Ok(discount);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreatePromotion([FromBody] Coupon coupon)
        {
            await _repository.CreatePromotion(coupon);
            return CreatedAtRoute("GetPromotion", new { productName = coupon.ProductName }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdatePanier([FromBody] Coupon coupon)
        {
            return Ok(await _repository.UpdatePromotion(coupon));
        }

        [HttpDelete("{productName}", Name = "DeletePromotion")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeletePromotion(string productName)
        {
            return Ok(await _repository.DeletePromotion(productName));
        }
    }
}
