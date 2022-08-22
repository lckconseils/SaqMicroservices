using System;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Promotion.Grpc.Protos;
using Promotion.Grpc.Repositories;

namespace Promotion.Grpc.Services
{
    public class PromotionService : PromotionProtoService.PromotionProtoServiceBase
    {
        private readonly ILogger<PromotionService> _logger;
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;

        public PromotionService(IPromotionRepository repository, IMapper mapper, ILogger<PromotionService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<CouponModel> GetPromotion(GetPromotionRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetPromotion(request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));
            }
            _logger.LogInformation("Discount is retrieved for ProductName : {productName}, montant : {montant}", coupon.ProductName, coupon.Montant);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> CreatePromotion(CreatePromotionRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _repository.CreatePromotion(coupon);
            _logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> UpdatePromotion(UpdatePromotionRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _repository.UpdatePromotion(coupon);
            _logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<DeletePromotionResponse> DeletePromotion(DeletePromotionRequest request, ServerCallContext context)
        {
            var deleted = await _repository.DeletePromotion(request.ProductName);
            var response = new DeletePromotionResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}
