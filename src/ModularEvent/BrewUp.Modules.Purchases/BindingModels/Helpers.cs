using BrewUp.Modules.Purchases.SharedKernel.Dtos;

namespace BrewUp.Modules.Purchases.BindingModels;

public static class Helpers
{
	public static SharedKernel.Dtos.OrderLine ToDto(this OrderLine orderLine)
	{
		return new SharedKernel.Dtos.OrderLine
		{
			BeerId = new SharedKernel.DomainIds.BeerId(orderLine.ProductId),
			BeerName = new BeerName(orderLine.Title),
			Quantity = new SharedKernel.Dtos.Quantity
			{
				Value = orderLine.Quantity.Value,
				UnitOfMeasure = orderLine.Quantity.UnitOfMeasure
			},
			Price = new SharedKernel.Dtos.Price
			{
				Value = orderLine.Price.Value,
				Currency = orderLine.Price.Currency
			}
		};
	}

	public static IEnumerable<SharedKernel.Dtos.OrderLine> ToDto(this IEnumerable<OrderLine> orderLines) => orderLines.Select(ToDto);
}