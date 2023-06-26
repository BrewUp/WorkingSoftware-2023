using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public class CreatePurchaseOrderHandlerAsync : CommandHandlerBaseAsync<CreatePurchaseOrder>
{
	public CreatePurchaseOrderHandlerAsync(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(CreatePurchaseOrder command, CancellationToken cancellationToken = default)
	{
		var aggregate = Order.Create(new PurchaseOrderId(command.AggregateId.Value), command.SupplierId, command.Date, command.Lines);
		Logger.LogInformation($"Order created aggregateId: {aggregate.Id.Value}");
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}