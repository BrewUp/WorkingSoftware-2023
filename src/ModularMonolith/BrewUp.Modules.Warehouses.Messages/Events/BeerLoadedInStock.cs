﻿using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Warehouses.Messages.Events;

public sealed class BeerLoadedInStock : DomainEvent
{
	public readonly BeerId BeerId;
	public readonly Stock Stock;
	public readonly Price Price;

	public readonly PurchaseOrderId PurchaseOrderId;

	public BeerLoadedInStock(BeerId aggregateId, Guid correlationId, Stock stock, Price price,
		PurchaseOrderId purchaseOrderId) : base(aggregateId, correlationId)
	{
		BeerId = aggregateId;
		Stock = stock;
		Price = price;
		PurchaseOrderId = purchaseOrderId;
	}
}