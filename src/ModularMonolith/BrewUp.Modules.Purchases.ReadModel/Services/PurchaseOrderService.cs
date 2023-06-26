using BrewUp.Modules.Purchases.ReadModel.Entities;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.DTOs;
using Microsoft.Extensions.Logging;

namespace BrewUp.Modules.Purchases.ReadModel.Services;

public class PurchaseOrderService : ServiceBase, IPurchaseOrderService
{
	public PurchaseOrderService(ILoggerFactory loggerFactory, IPurchasesPersister persister) : base(loggerFactory, persister)
	{
	}

	public async Task CreatePurchaseOrder(PurchaseOrderId purchaseOrderId, DateTime date, IEnumerable<OrderLine> lines,
		SupplierId supplierId)
	{
		var order = PurchaseOrder.Create(purchaseOrderId, date, lines, supplierId);

		await Persister.Insert(order);
	}

	public async Task UpdateStatusToComplete(PurchaseOrderId purchaseOrderId)
	{
		var order = await Persister.GetBy<PurchaseOrder>(purchaseOrderId.ToString());
		order.Status = Status.Complete;
		await Persister.Update(order);
	}
}