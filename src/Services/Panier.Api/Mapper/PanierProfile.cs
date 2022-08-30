using System;
using AutoMapper;
using EventBus.Messages.Events;

namespace Panier.Api.Mapper
{
    public class PanierProfile : Profile
    {
        public PanierProfile()
        {
            CreateMap<PanierCheckout, PanierCheckoutEvent>().ReverseMap();
        }
    }
}
