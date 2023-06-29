using BrewUp.Modules.Warehouses.Messages.Commands;
using BrewUp.Shared.Messages;
using MediatR;

namespace BrewUp.Modules.Warehouses.Sagas.Adapters;

public sealed class BeersReceivedEventHandler : INotificationHandler<BeersReceived>
{
	private readonly IMediator _serviceBus;

	public BeersReceivedEventHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public async Task Handle(BeersReceived @event, CancellationToken cancellationToken)
	{
		var command = new StartBeersReceivedSaga(@event.PurchaseOrderId, @event.OrderLines);
		await _serviceBus.Send(command, cancellationToken);
	}
}