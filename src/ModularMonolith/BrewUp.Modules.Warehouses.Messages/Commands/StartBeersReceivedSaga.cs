﻿using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Modules.Warehouses.Messages.Commands;

public sealed class StartBeersReceivedSaga : Command
{
	public readonly PurchaseOrderId PurchaseOrderId;

	public readonly IEnumerable<OrderLine> OrderLines;

	public StartBeersReceivedSaga(PurchaseOrderId aggregateId, IEnumerable<OrderLine> orderLines)
		: base(aggregateId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}