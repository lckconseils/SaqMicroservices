using System;
using AutoMapper;
using Commande.Application.Features.Orders.Commands.CheckoutOrder;
using Commande.Application.Features.Orders.Commands.UpdateOrder;
using Commande.Application.Features.Orders.Queries.GetOrdersList;
using Commande.Domaine.Entities;

namespace Commande.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
