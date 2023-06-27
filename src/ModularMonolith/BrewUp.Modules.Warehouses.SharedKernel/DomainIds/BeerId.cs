using Muflone.Core;

namespace BrewUp.Modules.Warehouses.SharedKernel.DomainIds;

public sealed class BeerId : DomainId
{
	public BeerId(Guid value) : base(value)
	{
	}
}