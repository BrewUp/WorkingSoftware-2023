using BrewUp.Modules.Warehouses.Messages.Commands;
using BrewUp.Modules.Warehouses.Messages.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public class CreateBeerCommandHandler : IRequestHandler<CreateBeer>
{
	private readonly IMediator _serviceBus;

	public CreateBeerCommandHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public async Task Handle(CreateBeer command, CancellationToken cancellationToken)
	{
		var beerCreated = new BeerCreated(command.BeerId, command.BeerName);
		await _serviceBus.Publish(beerCreated, cancellationToken);
	}
}