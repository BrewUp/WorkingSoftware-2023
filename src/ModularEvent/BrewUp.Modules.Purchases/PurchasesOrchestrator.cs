﻿using BrewUp.Modules.Purchases.BindingModels;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using MediatR;

namespace BrewUp.Modules.Purchases;

public sealed class PurchasesOrchestrator : IPurchasesOrchestrator
{
	private readonly IMediator _serviceBus;

	public PurchasesOrchestrator(IMediator serviceBus)
	{
		_serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
	}

	public async Task<string> CreateOrderAsync(Order order, CancellationToken cancellationToken)
	{
		//Application level validation
		var createOrder = new CreatePurchaseOrder(new PurchaseOrderId(order.Id),
			new SupplierId(order.SupplierId), order.Date,
			order.Lines.ToDto());

		await _serviceBus.Send(createOrder, cancellationToken);

		return order.Id.ToString();
	}

	public async Task ChangeStatusToComplete(Guid id, CancellationToken cancellationToken)
	{
		var command = new ChangePurchaseOrderStatusToComplete(new PurchaseOrderId(id));

		await _serviceBus.Send(command, cancellationToken);
	}
}