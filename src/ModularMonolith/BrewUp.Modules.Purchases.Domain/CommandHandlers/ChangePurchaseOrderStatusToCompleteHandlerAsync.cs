using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Modules.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public class ChangePurchaseOrderStatusToCompleteHandlerAsync : CommandHandlerBaseAsync<ChangePurchaseOrderStatusToComplete>
{
	public ChangePurchaseOrderStatusToCompleteHandlerAsync(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(ChangePurchaseOrderStatusToComplete command, CancellationToken cancellationToken = default)
	{
		var aggregate = await Repository.GetByIdAsync<Order>(command.AggregateId.Value);
		aggregate.Complete();

		Logger.LogInformation($"Order status changed to completed for aggregateId: {aggregate.Id.Value}");
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}