using BrewUp.Modules.Warehouses.Domain.Entities;
using BrewUp.Modules.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public sealed class CreateBeerCommandHandler : CommandHandlerBase<CreateBeer>
{
	public CreateBeerCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository,
		loggerFactory)
	{
	}

	public override async Task ProcessCommand(CreateBeer command, CancellationToken cancellationToken = default)
	{
		var aggregate = Beer.CreateBeer(command.BeerId, command.BeerName, command.MessageId);
		Logger.LogInformation($"Beer created aggregateId: {aggregate.Id.Value}");
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}