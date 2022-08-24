using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Panier.Api.Protos;
using Panier.API;

namespace Panier.Api.GrpcServices
{
    public class PromotionGrpcService
    {
        private readonly PromotionProtoService.PromotionProtoServiceClient _promotionProtoService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public PromotionGrpcService(PromotionProtoService.PromotionProtoServiceClient promotionProtoService, IHttpClientFactory httpClientFactory)
        {
            _promotionProtoService = promotionProtoService ?? throw new ArgumentNullException(nameof(promotionProtoService));
            this._httpClientFactory = httpClientFactory;
            this._httpClient = _httpClientFactory.CreateClient("Promotion");
        }

        public async Task<CouponModel> GetPromotion(string productName)
        {
            var discountRequest = new GetPromotionRequest { ProductName = productName };
            return await _promotionProtoService.GetPromotionAsync(discountRequest);
        }

        public async Task<Coupon> GetPromotionApi(string productName)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"api/v1/Promotion/{productName}");
            Coupon result =  null;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentAsString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<Coupon>(contentAsString);
            }
            return result;
        }
    }
}
