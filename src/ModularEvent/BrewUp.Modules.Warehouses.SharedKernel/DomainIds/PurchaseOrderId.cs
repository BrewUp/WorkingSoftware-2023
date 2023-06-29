using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Warehouses.SharedKernel.DomainIds;

public record PurchaseOrderId(Guid Value) : DomainId(Value);