using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.Messages.Events;

public record PurchaseOrderStatusChangedToComplete(PurchaseOrderId PurchaseOrderId, IEnumerable<OrderLine> Lines) : DomainEvent(PurchaseOrderId);