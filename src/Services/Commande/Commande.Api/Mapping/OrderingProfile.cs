using System;
using AutoMapper;
using Commande.Application.Features.Orders.Commands.CheckoutOrder;
using EventBus.Messages.Events;

namespace Commande.Api.Mapping
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, PanierCheckoutEvent>().ReverseMap();
        }
    }
}
