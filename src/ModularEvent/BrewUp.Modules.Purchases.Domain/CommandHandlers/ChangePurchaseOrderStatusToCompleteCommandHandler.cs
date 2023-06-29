using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.SharedKernel.Dtos;
using MediatR;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public class ChangePurchaseOrderStatusToCompleteCommandHandler : IRequestHandler<ChangePurchaseOrderStatusToComplete>
{
	private readonly IMediator _serviceBus;

	public ChangePurchaseOrderStatusToCompleteCommandHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public async Task Handle(ChangePurchaseOrderStatusToComplete request, CancellationToken cancellationToken)
	{
		// Do something
		var purchaseOrderStatusCompleted = new PurchaseOrderStatusChangedToComplete(request.PurchaseOrderId, Enumerable.Empty<OrderLine>());
		await _serviceBus.Publish(purchaseOrderStatusCompleted, cancellationToken);
	}
}