using Muflone.Core;

namespace BrewUp.Modules.Purchases.Domain.Entities;

public class Quantity : ValueObject
{
	public decimal Value { get; }
	public string UnitOfMeasure { get; }

	public Quantity(decimal value, string unitOfMeasure)
	{
		Value = value;
		UnitOfMeasure = unitOfMeasure;
	}

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
		yield return UnitOfMeasure;
	}
}