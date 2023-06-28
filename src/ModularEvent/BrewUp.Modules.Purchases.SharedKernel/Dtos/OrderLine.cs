using BrewUp.Modules.Purchases.SharedKernel.DomainIds;

namespace BrewUp.Modules.Purchases.SharedKernel.Dtos;

public class OrderLine
{
	public BeerId BeerId { get; set; } = default!;
	public BeerName BeerName { get; set; } = default!;
	public Quantity Quantity { get; set; } = default!;
	public Price Price { get; set; } = default!;
}