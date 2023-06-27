using BrewUp.Modules.Warehouses.ReadModel.Entities;
using BrewUp.Modules.Warehouses.SharedKernel.DomainIds;
using BrewUp.Modules.Warehouses.SharedKernel.Dtos;
using Microsoft.Extensions.Logging;

namespace BrewUp.Modules.Warehouses.ReadModel.Services;

public class BeerService : WarehouseBaseService, IBeerService
{
	public BeerService(ILoggerFactory loggerFactory, IWarehousesPersister persister) : base(loggerFactory, persister)
	{
	}

	public async Task<BeerId> AddBeerAsync(BeerId beerId, BeerName beerName,
		CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		try
		{
			var beer = await Persister.GetByIdAsync<Beer>(beerId.ToString(), cancellationToken);
			if (beer != null)
				return new BeerId(new Guid(beer.Id));

			beer = Beer.Create(beerId, beerName);
			await Persister.InsertAsync(beer, cancellationToken);

			return new BeerId(new Guid(beer.Id));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}

	public async Task LoadBeerInStockAsync(BeerId beerId, Stock stock, Price price, CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		try
		{
			var beer = await Persister.GetByIdAsync<Beer>(beerId.ToString(), cancellationToken);
			if (string.IsNullOrEmpty(beer.Id))
				return;

			beer.UpdateStock(stock);
			beer.UpdatePrice(price);
			await Persister.UpdateAsync(beer, cancellationToken);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}
}