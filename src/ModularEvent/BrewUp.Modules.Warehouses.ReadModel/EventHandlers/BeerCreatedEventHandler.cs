using BrewUp.Modules.Warehouses.Messages.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.ReadModel.EventHandlers;

public class BeerCreatedEventHandler : INotificationHandler<BeerCreated>
{
	public Task Handle(BeerCreated notification, CancellationToken cancellationToken)
	{
		// Update read model
		return Task.CompletedTask;
	}
}