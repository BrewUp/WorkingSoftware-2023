using BrewUp.Modules.Purchases.Messages.Events;
using MediatR;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderCreatedEventHandler : INotificationHandler<PurchaseOrderCreated>
{
	public Task Handle(PurchaseOrderCreated notification, CancellationToken cancellationToken)
	{
		// Update the read model
		return Task.CompletedTask;
	}
}