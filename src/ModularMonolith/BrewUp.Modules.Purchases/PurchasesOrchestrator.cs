using BrewUp.Modules.Purchases.BindingModels;
using Muflone.Persistence;

namespace BrewUp.Modules.Purchases;

public sealed class PurchasesOrchestrator : IPurchasesOrchestrator
{
	private readonly IServiceBus _serviceBus;

	public PurchasesOrchestrator(IServiceBus serviceBus)
	{
		_serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
	}

	public async Task<string> CreateOrderAsync(Order order, CancellationToken cancellationToken)
	{
		//Application level validation
		var createOrder = new CreatePurchaseOrder(new PurchaseOrderId(order.Id),
			new SupplierId(order.SupplierId), order.Date,
			order.Lines.ToDto());

		await _serviceBus.SendAsync(createOrder, cancellationToken);

		return order.Id.ToString();
	}

	public async Task ChangeStatusToComplete(Guid id, CancellationToken cancellationToken)
	{
		var command = new ChangePurchaseOrderStatusToComplete(new PurchaseOrderId(id));

		await _serviceBus.SendAsync(command, cancellationToken);
	}
}