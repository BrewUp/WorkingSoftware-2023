using Muflone.Core;

namespace BrewUp.Modules.Warehouses.SharedKernel.DomainIds;

public sealed class PurchaseOrderId : DomainId
{
	public PurchaseOrderId(Guid value) : base(value)
	{
	}
}