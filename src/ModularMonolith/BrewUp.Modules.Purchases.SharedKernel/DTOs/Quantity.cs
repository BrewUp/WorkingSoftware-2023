namespace BrewUp.Modules.Purchases.SharedKernel.DTOs;

public class Quantity
{
	public decimal Value { get; set; }
	public string UnitOfMeasure { get; set; } = string.Empty;
}