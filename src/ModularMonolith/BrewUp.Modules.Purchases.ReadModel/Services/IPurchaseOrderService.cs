using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.DTOs;

namespace BrewUp.Modules.Purchases.ReadModel.Services;

public interface IPurchaseOrderService
{
	Task CreatePurchaseOrder(PurchaseOrderId purchaseOrderId, DateTime date, IEnumerable<OrderLine> lines, SupplierId supplierId);
	Task UpdateStatusToComplete(PurchaseOrderId purchaseOrderId);
}