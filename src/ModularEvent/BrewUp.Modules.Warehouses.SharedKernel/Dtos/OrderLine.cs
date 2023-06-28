using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;

namespace BrewUp.Modules.Warehouses.SharedKernel.Dtos;

public record OrderLine(BeerId BeerId, BeerName BeerName, Quantity Quantity, Price Price);