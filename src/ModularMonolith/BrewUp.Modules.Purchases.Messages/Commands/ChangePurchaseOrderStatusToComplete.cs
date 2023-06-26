using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public class ChangePurchaseOrderStatusToComplete : Command
{
	public ChangePurchaseOrderStatusToComplete(PurchaseOrderId aggregateId) :
		base(aggregateId)
	{
	}
}