using System;
using AutoMapper;
using Promotion.Grpc.Protos;

namespace Promotion.Grpc.Mapper
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
