using BrewUp.Modules.Warehouses.Messages.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.Sagas.Adapters;

public sealed class BeersReceivedEventHandler : INotificationHandler<BeersReceived>
{
	private readonly IMediator _serviceBus;

	public BeersReceivedEventHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public Task Handle(BeersReceived notification, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}