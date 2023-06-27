using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Modules.Warehouses.ReadModel.Services;

public interface IBeerService
{
	Task<BeerId> AddBeerAsync(BeerId beerId, BeerName beerName, CancellationToken cancellationToken = default);
	Task LoadBeerInStockAsync(BeerId beerId, Stock stock, Price price, CancellationToken cancellationToken = default);
}