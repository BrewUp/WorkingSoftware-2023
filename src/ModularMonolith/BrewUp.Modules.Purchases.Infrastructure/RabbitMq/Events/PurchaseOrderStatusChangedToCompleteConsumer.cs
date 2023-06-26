using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.ReadModel.EventHandlers;
using BrewUp.Modules.Purchases.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Modules.Purchases.Infrastructure.RabbitMq.Events;

public sealed class
	PurchaseOrderStatusChangedToCompleteConsumer : DomainEventsConsumerBase<PurchaseOrderStatusChangedToComplete>
{
	protected override IEnumerable<IDomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>> HandlersAsync { get; }

	public PurchaseOrderStatusChangedToCompleteConsumer(IEventBus eventBus, IPurchaseOrderService purchaseOrderService, IMufloneConnectionFactory connectionFactory, ILoggerFactory loggerFactory)
		: base(connectionFactory, loggerFactory)
	{
		HandlersAsync = new List<IDomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>>
		{
			new PurchaseOrderStatusChangedToCompleteEventHandler(eventBus, loggerFactory, purchaseOrderService)
		};
	}
}