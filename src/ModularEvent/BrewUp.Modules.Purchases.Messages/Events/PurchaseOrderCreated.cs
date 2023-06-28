using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.Messages.Events;

public record PurchaseOrderCreated(PurchaseOrderId PurchaseOrderId,
	SupplierId SupplierId,
	DateTime Date,
	IEnumerable<OrderLine> Lines) : DomainEvent(PurchaseOrderId);