using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.SharedKernel.DomainIds;

public record PurchaseOrderId(Guid Value) : DomainId(Value);