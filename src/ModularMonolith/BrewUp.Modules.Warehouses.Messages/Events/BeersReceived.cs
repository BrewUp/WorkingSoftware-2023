﻿using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Warehouses.Messages.Events;

public sealed class BeersReceived : IntegrationEvent
{
	public readonly PurchaseOrderId PurchaseOrderId;
	public readonly IEnumerable<OrderLine> OrderLines;

	public BeersReceived(PurchaseOrderId aggregateId, Guid correlationId, IEnumerable<OrderLine> orderLines) : base(aggregateId, correlationId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}