using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.DTOs;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.Messages.Events;

public class PurchaseOrderStatusChangedToComplete : DomainEvent
{
	public PurchaseOrderStatusChangedToComplete(PurchaseOrderId aggregateId, IEnumerable<OrderLine> lines) : base(aggregateId)
	{
		Lines = lines;
	}

	public IEnumerable<OrderLine> Lines { get; init; }
}