using BrewUp.Modules.Warehouses.Domain.Entities;
using BrewUp.Modules.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public sealed class LoadBeerInStockCommandHandler : CommandHandlerBase<LoadBeerInStock>
{
	public LoadBeerInStockCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository,
		loggerFactory)
	{
	}

	public override async Task ProcessCommand(LoadBeerInStock command, CancellationToken cancellationToken = default)
	{
		var aggregate = await Repository.GetByIdAsync<Beer>(command.BeerId.Value);
		aggregate.LoadBeerInStock(command.BeerId, command.Stock, command.Price, command.PurchaseOrderId, command.MessageId);
		Logger.LogInformation($"Beer loaded in stock aggregateId: {aggregate.Id.Value}");
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}