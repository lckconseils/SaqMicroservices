using System;
using System.Threading.Tasks;

namespace Promotion.Grpc.Repositories
{
    public interface IPromotionRepository
    {
        Task<Coupon> GetPromotion(string productName);

        Task<bool> CreatePromotion(Coupon coupon);
        Task<bool> UpdatePromotion(Coupon coupon);
        Task<bool> DeletePromotion(string productName);
    }
}
