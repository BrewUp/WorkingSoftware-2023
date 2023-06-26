using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.ReadModel.Services;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using Microsoft.Extensions.Logging;
using Muflone;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public sealed class PurchaseOrderStatusChangedToCompleteEventHandler : DomainEventHandlerBase<PurchaseOrderStatusChangedToComplete>
{
	private readonly IEventBus _eventBus;
	private readonly IPurchaseOrderService _purchaseOrderService;

	public PurchaseOrderStatusChangedToCompleteEventHandler(IEventBus eventBus, ILoggerFactory loggerFactory, IPurchaseOrderService purchaseOrderService)
		  : base(loggerFactory)
	{
		_eventBus = eventBus;
		_purchaseOrderService = purchaseOrderService;
	}

	public override async Task HandleAsync(PurchaseOrderStatusChangedToComplete @event, CancellationToken cancellationToken = default)
	{
		await _purchaseOrderService.UpdateStatusToComplete(new PurchaseOrderId(@event.AggregateId.Value));

		//We are lazy, but in production it's advisable to create a dedicated EventHandler to send this integration event
		await _eventBus.PublishAsync(new BeersReceived(new PurchaseOrderId(@event.AggregateId.Value), Guid.NewGuid(), @event.Lines), cancellationToken);
	}
}