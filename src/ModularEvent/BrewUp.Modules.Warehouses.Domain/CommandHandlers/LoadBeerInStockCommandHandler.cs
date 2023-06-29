using BrewUp.Modules.Warehouses.Messages.Commands;
using BrewUp.Modules.Warehouses.Messages.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public class LoadBeerInStockCommandHandler : IRequestHandler<LoadBeerInStock>
{
	private readonly IMediator _serviceBus;

	public LoadBeerInStockCommandHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public async Task Handle(LoadBeerInStock request, CancellationToken cancellationToken)
	{
		var beerLoadedInStock = new BeerLoadedInStock(request.BeerId, request.Stock, request.Price, request.PurchaseOrderId);
		await _serviceBus.Publish(beerLoadedInStock, cancellationToken);
	}
}