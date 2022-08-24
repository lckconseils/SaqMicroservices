using System;
using System.Threading.Tasks;
using AutoMapper;
using Commande.Application.Features.Orders.Commands.CheckoutOrder;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Commande.Api.EventBusConsumer
{
    public class PanierCheckoutConsumer : IConsumer<PanierCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<PanierCheckoutConsumer> _logger;

        public PanierCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<PanierCheckoutConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<PanierCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);

            _logger.LogInformation("PanierCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
        }
    }
}
