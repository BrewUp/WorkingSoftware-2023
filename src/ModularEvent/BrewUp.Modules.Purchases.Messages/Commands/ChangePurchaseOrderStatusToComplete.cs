using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public record ChangePurchaseOrderStatusToComplete(PurchaseOrderId PurchaseOrderId) : Command(PurchaseOrderId);