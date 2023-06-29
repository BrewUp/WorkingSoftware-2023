using BrewUp.Modules.Purchases.Messages.Events;
using MediatR;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderStatusChangedToCompleteEventHandler : INotificationHandler<PurchaseOrderStatusChangedToComplete>
{
	public Task Handle(PurchaseOrderStatusChangedToComplete notification, CancellationToken cancellationToken)
	{
		// Update the read model
		return Task.CompletedTask;
	}
}