using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using Muflone.Core;

namespace BrewUp.Modules.Purchases.Domain.Entities;

public class OrderLine : Entity
{
	public BeerId BeerId { get; }
	public string Title { get; }
	public Quantity Quantity { get; }
	public Price Price { get; }

	public OrderLine(BeerId beerId, string title, Quantity quantity, Price price)
	{
		BeerId = beerId;
		Title = title;
		Quantity = quantity;
		Price = price;
	}
}