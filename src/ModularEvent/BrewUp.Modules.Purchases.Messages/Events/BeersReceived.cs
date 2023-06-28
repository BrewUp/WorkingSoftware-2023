using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.Messages.Events;

public record BeersReceived : IntegrationEvent
{
	public readonly PurchaseOrderId BuyOrderId;
	public readonly IEnumerable<OrderLine> OrderLines;

	public BeersReceived(PurchaseOrderId purchaseOrderId, IEnumerable<OrderLine> orderLines) : base(purchaseOrderId)
	{
		BuyOrderId = purchaseOrderId;
		OrderLines = orderLines;
	}
}