using BrewUp.Modules.Warehouses.ReadModel.Entities;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using Microsoft.Extensions.Logging;

namespace BrewUp.Modules.Warehouses.ReadModel.Services;

public class WarehouseAvailabilityService : WarehouseBaseService, IWarehouseAvailabilityService
{
	private readonly IWarehousesQueries<Beer> _queries;

	public WarehouseAvailabilityService(ILoggerFactory loggerFactory,
		IWarehousesPersister persister,
		IWarehousesQueries<Beer> queries) : base(loggerFactory, persister)
	{
		_queries = queries;
	}

	public async Task<PagedResult<BeerJson>> GetBeerAvailabilityAsync(CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		try
		{
			var beerAvailability = await _queries.GetByFilterAsync(null, 0, 200);

			return beerAvailability.TotalRecords > 0
				? new PagedResult<BeerJson>(beerAvailability.Results.Select(r => r.ToJson()), beerAvailability.Page, beerAvailability.PageSize, beerAvailability.TotalRecords)
				: new PagedResult<BeerJson>(new List<BeerJson>(), 0, 0, 0);
		}
		catch (Exception ex)
		{
			Logger.LogError($"WarehouseAvailabilityService: {ex.StackTrace} - {ex.Source} - {ex.Message}");
			throw;
		}
	}
}
