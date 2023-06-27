using BrewUp.Modules.Warehouses.ReadModel.Entities;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;

namespace BrewUp.Modules.Warehouses.ReadModel.Services;

public interface IWarehouseAvailabilityService
{
	Task<PagedResult<BeerJson>> GetBeerAvailabilityAsync(CancellationToken cancellationToken);
}