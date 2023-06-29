using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Warehouses.Messages.Events;

public record BeersReceived : IntegrationEvent
{
	public readonly PurchaseOrderId PurchaseOrderId;
	public readonly IEnumerable<OrderLine> OrderLines;

	public BeersReceived(PurchaseOrderId aggregateId, IEnumerable<OrderLine> orderLines) : base(aggregateId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}