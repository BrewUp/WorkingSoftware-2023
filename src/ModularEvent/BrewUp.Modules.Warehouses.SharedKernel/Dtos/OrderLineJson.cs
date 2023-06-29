using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Warehouses.SharedKernel.Dtos;

public record OrderLineJson(string BeerId, string BeerName, Quantity Quantity, Price Price);