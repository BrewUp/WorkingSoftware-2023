using Microsoft.Extensions.Logging;

namespace BrewUp.Modules.Warehouses.ReadModel.Services;

public abstract class WarehouseBaseService
{
	protected ILogger Logger;

	protected IWarehousesPersister Persister;

	protected WarehouseBaseService(ILoggerFactory loggerFactory, IWarehousesPersister persister)
	{
		Logger = loggerFactory.CreateLogger(GetType());
		Persister = persister;
	}
}