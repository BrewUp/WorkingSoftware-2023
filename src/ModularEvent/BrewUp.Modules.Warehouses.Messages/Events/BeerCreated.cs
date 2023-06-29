using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Warehouses.Messages.Events;

public record BeerCreated : DomainEvent
{
	public readonly BeerId BeerId;
	public readonly BeerName BeerName;

	public BeerCreated(BeerId BeerId, BeerName beerName) : base(BeerId)
	{
		this.BeerId = BeerId;
		BeerName = beerName;
	}
}