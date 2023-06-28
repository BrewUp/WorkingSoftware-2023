using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public record CreatePurchaseOrder(PurchaseOrderId PurchaseOrderId,
	SupplierId SupplierId,
	DateTime Date,
	IEnumerable<OrderLine> Lines) : Command(PurchaseOrderId);