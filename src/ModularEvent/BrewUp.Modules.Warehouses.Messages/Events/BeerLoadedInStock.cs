using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Warehouses.Messages.Events;

public record BeerLoadedInStock : DomainEvent
{
	public readonly BeerId BeerId;
	public readonly Stock Stock;
	public readonly Price Price;

	public readonly PurchaseOrderId PurchaseOrderId;

	public BeerLoadedInStock(BeerId aggregateId, Stock stock, Price price,
		PurchaseOrderId purchaseOrderId) : base(aggregateId)
	{
		BeerId = aggregateId;
		Stock = stock;
		Price = price;
		PurchaseOrderId = purchaseOrderId;
	}
}